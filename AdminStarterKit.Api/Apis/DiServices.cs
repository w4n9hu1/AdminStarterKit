using AdminStarterKit.Domain;
using AdminStarterKit.Infrastructure;
using AutoMapper;
using System.Security.Claims;

namespace AdminStarterKit.Api.Apis
{
    public class DiServices(
        MdmContext mdmContext,
        ITokenService tokenService,
        ClaimsPrincipal claims,
        IMapper mapper)
    {
        public MdmContext MdmContext { get; set; } = mdmContext;
        public ITokenService TokenService { get; set; } = tokenService;

        public ClaimsPrincipal Claims { get; set; } = claims;
        public int UserId
        {
            get
            {
                if (int.TryParse(claims?.Identity?.Name, out int userId))
                {
                    return userId;
                }
                return 0;
            }
        }
        public IMapper Mapper { get; set; } = mapper;
    }
}
