using HA_ERP.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HA_ERP.Organizations
{
    public interface IOrganizationAppService : IApplicationService
    {
        Task<CreateOrganizationDto> GetAsync(int id);

        Task<PagedResultDto<OrganizationDto>> GetListAsync(GetStaffListDto input);

        Task<OrganizationDto> CreateAsync(CreateOrganizationDto input);

        Task UpdateAsync(int id, UpdateOrganizationDto input);

        Task DeleteAsync(int id);
    }
}
