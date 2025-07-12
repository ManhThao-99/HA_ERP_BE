using AutoMapper;
using HA_ERP.Organizations;
using HA_ERP.Staffs;

namespace HA_ERP;

public class HA_ERPApplicationAutoMapperProfile : Profile
{
    public HA_ERPApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Staff, StaffDto>().ReverseMap();
        CreateMap<CreateStaffDto, Staff>().ReverseMap();
        CreateMap<UpdateStaffDto, Staff>().ReverseMap();
        CreateMap<StaffSimpleDto, Staff>().ReverseMap();


        CreateMap<Organization, OrganizationDto>().ReverseMap();
        CreateMap<UpdateOrganizationDto, Organization>().ReverseMap();
    }
}
    