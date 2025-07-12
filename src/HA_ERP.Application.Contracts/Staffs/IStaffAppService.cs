using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HA_ERP.Staffs
{
    public interface IStaffAppService : IApplicationService
    {
        Task<StaffDto> GetAsync(int id);

        Task<PagedResultDto<StaffDto>> GetListAsync();

        Task<PagedResultDto<StaffDto>> GetListByOrganizationAsync(int id, PagedAndSortedResultRequestDto input);

        Task <List<StaffSimpleDto>> GetManager(int id);

        Task<StaffDto> CreateAsync(CreateStaffDto input);

        Task UpdateAsync(int id, UpdateStaffDto input);

        Task DeleteAsync(int id);



    }
}
