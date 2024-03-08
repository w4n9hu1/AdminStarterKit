using AdminStarterKit.Api.Contracts;
using AdminStarterKit.Domain.Aggregates;
using AutoMapper;

namespace AdminStarterKit.Api.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Role, RoleDto>();
        }
    }
}
