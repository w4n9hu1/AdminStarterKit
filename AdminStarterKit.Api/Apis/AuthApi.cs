
using AdminStarterKit.Api.Contracts;
using AdminStarterKit.Api.Validations;
using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Shared;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminStarterKit.Api.Apis
{
    public static class AuthApi
    {
        public static RouteGroupBuilder MapAuthApi(this RouteGroupBuilder builder)
        {
            builder.MapPost("/login", LoginAsync).AllowAnonymous();
            builder.MapPost("/changePassword", ChangePaawordAsync);
            return builder;
        }

        public static async Task<Results<Ok<string>, BadRequest<string>>> ChangePaawordAsync([FromBody] ChangePasswordRequest request, [AsParameters] DiServices services)
        {
            var validator = new ChangePasswordRequestValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid == false)
            {
                return TypedResults.BadRequest(validationResult.ToString());
            }
            var user = await services.MdmContext.Users.SingleOrDefaultAsync(u => u.Id == request.UserId);
            if (user == null)
            {
                return TypedResults.BadRequest(Resources.UserNotFound());
            }
            var validPassword = PasswordHasher.VerifyPassword(request.OldPassword, user.PasswordHash);
            if (!validPassword)
            {
                return TypedResults.BadRequest(Resources.PasswordMismatch());
            }
            user.Password = request.NewPassword;
            user.HashPassWord();
            await services.MdmContext.SaveChangesAsync();
            return TypedResults.Ok(Resources.ChangePasswordSuccessful());
        }

        public static async Task<Results<Ok<AccessTokenResponse>, BadRequest<string>>> LoginAsync([FromBody] LoginRequest request, [AsParameters] DiServices services)
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
