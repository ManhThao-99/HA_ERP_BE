using HA_ERP.Organizations;
using HA_ERP.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HA_ERP.Staffs
{
    [Authorize(HA_ERPPermissions.Staffs.Default)]
    public class StaffAppService : HA_ERPAppService, IStaffAppService
    {
        private readonly IOrganizationAppService _organizationAppService;

        private readonly IStaffRepository _staffRepository;

        public StaffAppService(IOrganizationAppService organizationAppService, IStaffRepository staffRepository)
        {
            _organizationAppService = organizationAppService;
            _staffRepository = staffRepository;
        }
        [Authorize(HA_ERPPermissions.Staffs.Create)]
        public Task<StaffDto> CreateAsync(CreateStaffDto input)
        {
            throw new NotImplementedException();
        }
        [Authorize(HA_ERPPermissions.Staffs.Delete)]
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<StaffDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<PagedResultDto<StaffDto>> GetListAsync(GetStaffListDto input)
        {
            throw new NotImplementedException();
        }
        [Authorize(HA_ERPPermissions.Staffs.Update)]

        public Task UpdateAsync(int id, UpdateStaffDto input)
        {
            throw new NotImplementedException();
        }
 
    }
}
