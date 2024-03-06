using AdminStarterKit.Api.Contracts;
using AdminStarterKit.Api.Extensions;
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

app.MapPost("/user", ([FromBody] CreateUserRequest request) =>
{
    return request.UserName;
});

app.Run();
