using AdminStarterKit.Api.Contracts;
using AdminStarterKit.Api.Extensions;
using AdminStarterKit.Api.Validations;
using AdminStarterKit.Domain.Aggregates;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () =>
{
    return "weatherforecast";
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapPost("/user", async ([FromBody] CreateUserRequest request, [FromServices] IServiceProvider sp) =>
{
    var validator = new CreateUserRequestValidator();
    // validator.ValidateAndThrow(request);
    var validationResult = await validator.ValidateAsync(request);

    var user = new User
    {
        Email = request.Email,
        UserName = request.UserName,
        PasswordHash = request.Password
    };
    var userRepository = sp.GetRequiredService<IUserRepository>();
    userRepository.Add(user);
    await userRepository.UnitOfWork.SaveChangesAsync();
    return request.UserName;
});

app.Run();
