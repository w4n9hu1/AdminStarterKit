using AdminStarterKit.Api;
using AdminStarterKit.Application;
using AdminStarterKit.Application.Contracts;
using AdminStarterKit.Domain.Enums;
using AdminStarterKit.Domain.Identity;
using AdminStarterKit.Domain.Shared;
using AdminStarterKit.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(JwtConfig.Position));
var jwtConfig = builder.Configuration.GetSection(JwtConfig.Position).Get<JwtConfig>();

var corsOrigins = builder.Configuration.GetSection("CorsOrigins").Get<string[]>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    if (corsOrigins != null && corsOrigins.Length > 0)
    {
        options.AddPolicy(name: MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins(corsOrigins)
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                          });
    }
});

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = jwtConfig.Issuer,
        ValidateAudience = false,
        ValidAudience = jwtConfig.Audience,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key))
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.RequireRole(RoleName.Admin.ToString()));
    options.AddPolicy("operator", policy => policy.RequireRole(RoleName.Operator.ToString()));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.MapPost("/register", async Task<Results<Ok, ValidationProblem>> (RegisterRequest request,
    [FromServices] IServiceProvider sp) =>
{
    return TypedResults.Ok();
});

app.MapPost("/login", async Task<Results<Ok<AccessTokenResponse>, ProblemHttpResult>> (LoginRequest request, [FromServices] IServiceProvider sp) =>
{
    var userRepository = sp.GetRequiredService<IUserRepository>();
    var user = await userRepository.FindByEmailAsync(request.Email);
    if (user == null)
    {
        return TypedResults.Problem("invlaid user", statusCode: StatusCodes.Status401Unauthorized);
    }
    var tokenService = sp.GetRequiredService<ITokenService>();
    var tokenResponse = new AccessTokenResponse
    {
        AccessToken = tokenService.GenerateAccessToken(user),
        RefreshToken = tokenService.GenerateRefreshToken(user)
    };
    return TypedResults.Ok(tokenResponse);
});

app.MapGet("/refresh", () =>
{
    return "hello world";
});

app.MapGet("/dashboard", () =>
{
    return "hello world";
}).RequireAuthorization();

app.MapGet("/operator", (ClaimsPrincipal user) =>
{
    return $"hello {user?.Identity?.Name}";
})
.RequireAuthorization("operator");

app.MapGet("/admin", (ClaimsPrincipal user) =>
{
    return $"hello {user?.Identity?.Name}";
})
.RequireAuthorization("admin");

app.Run();
