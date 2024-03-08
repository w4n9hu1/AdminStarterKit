using AdminStarterKit.Domain.Aggregates;
using AdminStarterKit.Infrastructure;
using AutoMapper;

namespace AdminStarterKit.Api.Apis
{
    public class MdmServices(
        MdmContext mdmContext,
        IMapper mapper)
    {
        public MdmContext MdmContext { get; set; } = mdmContext;
        public IMapper Mapper { get; set; } = mapper;
    }
}
