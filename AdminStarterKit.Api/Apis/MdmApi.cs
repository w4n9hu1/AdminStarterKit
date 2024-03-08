using AdminStarterKit.Api.Contracts;
using AdminStarterKit.Api.Validations;
using AdminStarterKit.Domain;
using AdminStarterKit.Domain.Aggregates;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminStarterKit.Api.Apis
{
    public static class MdmApi
    {
        public static RouteGroupBuilder MapMdmApi(this RouteGroupBuilder builder)
        {
            builder.MapPost("/user", CreateUserAsync);
            builder.MapGet("/user", GetAllUserAsync);
            builder.MapGet("/user/{userId:int}", GetUserByIdAsync);
            builder.MapDelete("user/{userId:int}", DeleteUserAsync);
            builder.MapPut("user/{userId:int}", UpdateUserAsync);

            builder.MapPost("/role", CreateRoleAsync);
            builder.MapGet("/role", GetAllRoleAsync);
            builder.MapGet("/role/{roleId:int}", GetRoleByIdAsync);
            builder.MapDelete("role/{roleId:int}", DeleteRoleAsync);
            builder.MapPut("role/{roleId:int}", UpdateRoleAsync);

            builder.MapPost("/bindRoleToUser", BindRoleToUserAsync);
            return builder;
        }

        private static async Task<Results<Ok, NotFound<string>>> BindRoleToUserAsync([FromBody] BindRoleToUserRequest request, [AsParameters] MdmServices services)
        {
            var user = await services.MdmContext.Users.FindAsync(request.UserId);
            if (user == null)
            {
                return TypedResults.NotFound(Resources.NotFound(nameof(request.UserId)));
            }
            var roles = new List<Role>();
            if (request.RoleIds?.Count > 0)
            {
                roles = await services.MdmContext.Roles.Where(r => request.RoleIds.Contains(r.Id)).ToListAsync();
            }
            user.Roles = roles;
            await services.MdmContext.SaveChangesAsync();
            return TypedResults.Ok();
        }

        public static async Task<Ok<List<UserDto>>> GetAllUserAsync([AsParameters] MdmServices services)
        {
            var users = await services.MdmContext.Users.OrderBy(u => u.CreatedDateTime).ToListAsync();
            var usersDto = services.Mapper.Map<List<UserDto>>(users);
            return TypedResults.Ok(usersDto);
        }

        public static async Task<Results<Ok<UserDto>, NotFound<string>>> GetUserByIdAsync(int userId, [AsParameters] MdmServices services)
        {
            var user = await services.MdmContext.Users.FindAsync(userId);
            if (user == null)
            {
                return TypedResults.NotFound(Resources.NotFound(nameof(userId)));
            }
            var userDto = services.Mapper.Map<UserDto>(user);
            return TypedResults.Ok(userDto);
        }

        public static async Task<Results<Ok, BadRequest<string>>> CreateUserAsync([FromBody] CreateUserRequest request, [AsParameters] MdmServices services)
        {
            var validator = new CreateUserRequestValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid == false)
            {
                return TypedResults.BadRequest(validationResult.ToString());
            }
            var user = new User
            {
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };
            user.HashPassWord();
            services.MdmContext.Users.Add(user);
            await services.MdmContext.SaveChangesAsync();
            return TypedResults.Ok();
        }

        public static async Task<Results<Ok, NotFound<string>, BadRequest<string>>> UpdateUserAsync(int userId, [FromBody] CreateUserRequest request, [AsParameters] MdmServices services)
        {
            var user = services.MdmContext.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return TypedResults.NotFound(Resources.NotFound(nameof(userId)));
            }
            var validator = new CreateUserRequestValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid == false)
            {
                return TypedResults.BadRequest(validationResult.ToString());
            }
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.UpdatedDateTime = DateTimeOffset.Now;
            await services.MdmContext.SaveChangesAsync();
            return TypedResults.Ok();
        }

        public static async Task<Ok> DeleteUserAsync(int userId, [AsParameters] MdmServices services)
        {
            var user = services.MdmContext.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return TypedResults.Ok();
            }
            services.MdmContext.Users.Remove(user);
            await services.MdmContext.SaveChangesAsync();
            return TypedResults.Ok();
        }


        public static async Task<Results<Ok, BadRequest<string>>> CreateRoleAsync([FromBody] CreateRoleRequest request, [AsParameters] MdmServices services)
        {
            var validator = new CreateRoleRequestValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid == false)
            {
                return TypedResults.BadRequest(validationResult.ToString());
            }
            var role = new Role
            {
                RoleName = request.RoleName
            };
            services.MdmContext.Roles.Add(role);
            await services.MdmContext.SaveChangesAsync();
            return TypedResults.Ok();
        }

        public static async Task<Ok<List<RoleDto>>> GetAllRoleAsync([AsParameters] MdmServices services)
        {
            var roles = await services.MdmContext.Roles.OrderBy(u => u.CreatedDateTime).ToListAsync();
            var rolesDto = services.Mapper.Map<List<RoleDto>>(roles);
            return TypedResults.Ok(rolesDto);
        }

        public static async Task<Results<Ok<RoleDto>, NotFound<string>>> GetRoleByIdAsync(int roleId, [AsParameters] MdmServices services)
        {
            var role = await services.MdmContext.Roles.FindAsync(roleId);
            if (role == null)
            {
                return TypedResults.NotFound(Resources.NotFound(nameof(roleId)));
            }
            var roleDto = services.Mapper.Map<RoleDto>(role);
            return TypedResults.Ok(roleDto);
        }

        public static async Task<Results<Ok, NotFound<string>, BadRequest<string>>> UpdateRoleAsync(int roleId, [FromBody] CreateRoleRequest request, [AsParameters] MdmServices services)
        {
            var role = services.MdmContext.Roles.SingleOrDefault(u => u.Id == roleId);
            if (role == null)
            {
                return TypedResults.NotFound(Resources.NotFound(nameof(roleId)));
            }
            var validator = new CreateRoleRequestValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.IsValid == false)
            {
                return TypedResults.BadRequest(validationResult.ToString());
            }
            role.RoleName = request.RoleName;
            await services.MdmContext.SaveChangesAsync();
            return TypedResults.Ok();
        }

        public static async Task<Ok> DeleteRoleAsync(int roleId, [AsParameters] MdmServices services)
        {
            var role = services.MdmContext.Roles.SingleOrDefault(u => u.Id == roleId);
            if (role == null)
            {
                return TypedResults.Ok();
            }
            services.MdmContext.Roles.Remove(role);
            await services.MdmContext.SaveChangesAsync();
            return TypedResults.Ok();
        }

    }
}
