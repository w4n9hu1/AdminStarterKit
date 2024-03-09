using AdminStarterKit.Domain;
using AdminStarterKit.Infrastructure;
using AutoMapper;

namespace AdminStarterKit.Api.Apis
{
    public class DiServices(
        MdmContext mdmContext,
        ITokenService tokenService,
        IMapper mapper)
    {
        public MdmContext MdmContext { get; set; } = mdmContext;
        public ITokenService TokenService { get; set; } = tokenService;
        public IMapper Mapper { get; set; } = mapper;
    }
}
