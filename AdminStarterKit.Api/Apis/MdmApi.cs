using AdminStarterKit.Api.Contracts;
using AdminStarterKit.Api.Validations;
using AdminStarterKit.Domain.Aggregates;
using Microsoft.AspNetCore.Mvc;

namespace AdminStarterKit.Api.Apis
{
    public static class MdmApi
    {
        public static RouteGroupBuilder MapMdmApi(this RouteGroupBuilder builder)
        {
            builder.MapPost("/user", CreateUser);
            return builder;
        }

        public static async Task<CommonApiResponse<UserDto>> CreateUser([FromBody] CreateUserRequest request, [AsParameters] MdmServices services)
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
            services.UserRepository.Add(user);
            await services.UserRepository.UnitOfWork.SaveChangesAsync();
            var userDto = services.Mapper.Map<UserDto>(user);
            return CommonApiResponse<UserDto>.Success(userDto);
        }
    }
}
