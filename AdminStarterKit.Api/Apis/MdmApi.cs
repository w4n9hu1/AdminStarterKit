using AdminStarterKit.Api.Contracts;
using AdminStarterKit.Api.Validations;
using AdminStarterKit.Domain.Aggregates;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdminStarterKit.Api.Apis
{
    public static class MdmApi
    {
        public static RouteGroupBuilder MapMdmApi(this RouteGroupBuilder builder)
        {
            builder.MapPost("/user", async Task<CommonApiResponse<UserDto>> ([FromBody] CreateUserRequest request, [FromServices] IServiceProvider sp) =>
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
            return builder;
        }
    }
}
