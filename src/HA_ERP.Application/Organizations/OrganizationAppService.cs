using HA_ERP.Permissions;
using HA_ERP.Staffs;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HA_ERP.Organizations
{
    [Authorize(HA_ERPPermissions.Organizations.Default)]
    public class OrganizationAppService : HA_ERPAppService, IOrganizationAppService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly OrganizationManager _organizationManager;

        public OrganizationAppService(IOrganizationRepository organizationRepository, OrganizationManager organizationManager)
        {
            _organizationRepository = organizationRepository;
            _organizationManager = organizationManager;
        }

        [Authorize(HA_ERPPermissions.Organizations.Create)]
        public Task<OrganizationDto> CreateAsync(CreateOrganizationDto input)
        {
            throw new NotImplementedException();
        }

        [Authorize(HA_ERPPermissions.Organizations.Delete)]
        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CreateOrganizationDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<OrganizationDto>> GetListAsync(GetStaffListDto input)
        {
            throw new NotImplementedException();
        }
        [Authorize(HA_ERPPermissions.Organizations.Update)]

        public Task UpdateAsync(int id, UpdateOrganizationDto input)
        {
            throw new NotImplementedException();
        }
    }
}
