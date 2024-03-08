using AdminStarterKit.Api.Contracts;
using AdminStarterKit.Api.Extensions;
using AdminStarterKit.Api.Validations;
using AdminStarterKit.Domain.Aggregates;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

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

app.MapPost("/user", async Task<CommonApiResponse<UserDto>> ([FromBody] CreateUserRequest request, [FromServices] IServiceProvider sp) =>
{
    var validator = new CreateUserRequestValidator();
    var validationResult = await validator.ValidateAsync(request);
    if (validationResult.IsValid == false)
    {
        return CommonApiResponse<UserDto>.Failed(validationResult.ToString());
    }
    var user = new User
    {
        Email = request.Email,
        UserName = request.UserName,
        PasswordHash = request.Password,
        CreatedDateTime = DateTimeOffset.UtcNow,
        UpdatedDateTime = DateTimeOffset.UtcNow
    };
    var userRepository = sp.GetRequiredService<IUserRepository>();
    userRepository.Add(user);
    await userRepository.UnitOfWork.SaveChangesAsync();
    var mapper = sp.GetRequiredService<IMapper>();
    var userDto = mapper.Map<UserDto>(user);
    return CommonApiResponse<UserDto>.Success(userDto);
});

app.Run();
