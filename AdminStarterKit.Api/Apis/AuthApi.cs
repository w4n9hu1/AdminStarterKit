
using AdminStarterKit.Api.Contracts;
using AdminStarterKit.Api.Validations;
using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminStarterKit.Api.Apis
{
    public static class AuthApi
    {
        public static RouteGroupBuilder MapAuthApi(this RouteGroupBuilder builder)
        {
            builder.MapPost("/login", LoginAsync);
            return builder;
        }

        private static async Task<Results<Ok<AccessTokenResponse>, BadRequest<string>>> LoginAsync([FromBody] LoginRequest request, [AsParameters] DiServices services)
        {
            var validator = new LoginRequestValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid == false)
            {
                return TypedResults.BadRequest(validationResult.ToString());
            }
            var user = await services.MdmContext.Users.Include(u => u.Roles).SingleOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return TypedResults.BadRequest(Resources.EmailNotFound(request.Email));
            }
            var validPassword = PasswordHasher.VerifyPassword(request.Password, user.PasswordHash);
            if (!validPassword)
            {
                return TypedResults.BadRequest(Resources.PasswordMismatch());
            }
            var tokenResponse = new AccessTokenResponse
            {
                AccessToken = services.TokenService.GenerateAccessToken(user),
                RefreshToken = services.TokenService.GenerateRefreshToken(user)
            };
            return TypedResults.Ok(tokenResponse);
        }
    }
}
