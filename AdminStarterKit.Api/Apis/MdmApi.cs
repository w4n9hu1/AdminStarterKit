using AdminStarterKit.Api.Contracts;
using AdminStarterKit.Api.Validations;
using AdminStarterKit.Domain.Aggregates;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AdminStarterKit.Api.Apis
{
    public static class MdmApi
    {
        public static RouteGroupBuilder MapMdmApi(this RouteGroupBuilder builder)
        {
            builder.MapPost("/user", CreateUserAsync);
            builder.MapGet("/user", GetAllUserAsync);
            builder.MapGet("/user/{userId:int}", GetUserAsync);
            builder.MapDelete("user/{userId:int}", DeleteUserAsync);
            builder.MapPut("user/{userId:int}", UpdateUserAsync);
            return builder;
        }
        public static async Task<CommonApiResponse<UserDto>> CreateUserAsync([FromBody] CreateUserRequest request, [AsParameters] MdmServices services)
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
            services.MdmContext.Users.Add(user);
            await services.MdmContext.SaveChangesAsync();
            var userDto = services.Mapper.Map<UserDto>(user);
            return CommonApiResponse<UserDto>.Success(userDto);
        }

        public static async Task<CommonApiResponse<List<UserDto>>> GetAllUserAsync([AsParameters] MdmServices services)
        {
            var users = services.MdmContext.Users;
            var userDto = services.Mapper.Map<List<UserDto>>(users);
            return CommonApiResponse<List<UserDto>>.Success(userDto);
        }

        public static async Task UpdateUserAsync(int userId, [FromBody] CreateUserRequest request, [AsParameters] MdmServices services)
        {
            var user = services.MdmContext.Users.SingleOrDefault(u => u.Id == userId);
            user.UserName = request.UserName;
            await services.MdmContext.SaveChangesAsync();
        }

        public static async Task<Results<NoContent, NotFound>> DeleteUserAsync(int userId, [AsParameters] MdmServices services)
        {
            var user = services.MdmContext.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return TypedResults.NotFound();
            }
            services.MdmContext.Users.Remove(user);
            await services.MdmContext.SaveChangesAsync();
            return TypedResults.NoContent();
        }

        public static async Task<CommonApiResponse<UserDto>> GetUserAsync(int userId, [AsParameters] MdmServices services)
        {
            var user = await services.MdmContext.Users.FindAsync(userId);
            if (user == null)
            {
                return CommonApiResponse<UserDto>.Failed("not found");
            }
            var userDto = services.Mapper.Map<UserDto>(user);
            return CommonApiResponse<UserDto>.Success(userDto);
        }


    }
}
