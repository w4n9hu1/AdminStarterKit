using AdminStarterKit.Domain.Aggregates;
using AutoMapper;

namespace AdminStarterKit.Api.Apis
{
    public class MdmServices(
        IMapper mapper,
        IUserRepository userRepository)
    {
        public IMapper Mapper { get; set; } = mapper;
        public IUserRepository UserRepository { get; set; } = userRepository;
    }
}
