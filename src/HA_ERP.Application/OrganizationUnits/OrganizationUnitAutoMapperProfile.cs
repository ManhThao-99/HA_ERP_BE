using AutoMapper;
using Volo.Abp.Identity;

namespace HA_ERP.OrganizationUnits
{
    public class OrganizationUnitAutoMapperProfile : Profile
    {
        public OrganizationUnitAutoMapperProfile()
        {
            CreateMap<OrganizationUnit, OrganizationUnitDto>();
            CreateMap<CreateOrganizationUnitDto, OrganizationUnit>();
            CreateMap<UpdateOrganizationUnitDto, OrganizationUnit>();
            CreateMap<OrganizationUnit, OrganizationUnitTreeDto>();

        }
    }
}