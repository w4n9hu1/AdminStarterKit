using AdminStarterKit.Application;
using AdminStarterKit.Application.Contracts;
using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Shared;
using AdminStarterKit.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(JwtConfig.Position));
var jwtConfig = builder.Configuration.GetSection(JwtConfig.Position).Get<JwtConfig>();

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
    options.AddPolicy("admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("operator", policy => policy.RequireRole("Operator"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () =>
{
    return "hello world";
});

app.MapGet("/register", () =>
{
    return "hello world";
});


app.MapPost("/login", (LoginRequest request, IUserRepository userRepository, ITokenService tokenService) =>
{
    var user = userRepository.Find(request.UserName, request.Password);
    if (user == null)
    {
        return "invalid user.";
    }
    var token = tokenService.GenerateToken(user.UserName, user.Role);
    return token;
});

app.MapGet("/user", (ClaimsPrincipal user) =>
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
