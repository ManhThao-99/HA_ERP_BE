using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HA_ERP.Permissions;
using HA_ERP.Staffs;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace HA_ERP.Organizations
{
    [Authorize(HA_ERPPermissions.Organizations.Default)]
    public class OrganizationAppService : HA_ERPAppService, IOrganizationAppService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly OrganizationManager _organizationManager;

        public OrganizationAppService(
            IOrganizationRepository organizationRepository,
            OrganizationManager organizationManager
        )
        {
            _organizationRepository = organizationRepository;
            _organizationManager = organizationManager;
        }

        [Authorize(HA_ERPPermissions.Organizations.Create)]
        public async Task<OrganizationDto> CreateAsync(CreateOrganizationDto input)
        {
            var org = new Organization { Name = input.Name, Code = input.Code };

            await _organizationRepository.InsertAsync(org);

            return ObjectMapper.Map<Organization, OrganizationDto>(org);
        }

        [Authorize(HA_ERPPermissions.Organizations.Delete)]
        public async Task DeleteAsync(int id)
        {
            await _organizationRepository.DeleteAsync(id);
        }

        public async Task<OrganizationDto> GetAsync(int id)
        {
            var organization = await _organizationRepository.GetAsync(id);
            return ObjectMapper.Map<Organization, OrganizationDto>(organization);
        }

        public async Task<PagedResultDto<OrganizationDto>> GetListAsync(
            GetListOrganizationDto input
        )
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Organization.Name);
            }

            var organizations = await _organizationRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount =
                input.Filter == null
                    ? await _organizationRepository.CountAsync()
                    : await _organizationRepository.CountAsync(author =>
                        author.Name.Contains(input.Filter)
                    );

            return new PagedResultDto<OrganizationDto>(
                totalCount,
                ObjectMapper.Map<List<Organization>, List<OrganizationDto>>(organizations)
            );
        }

        [Authorize(HA_ERPPermissions.Organizations.Update)]
        public async Task UpdateAsync(int id, UpdateOrganizationDto input)
        {
            var org = await _organizationRepository.GetAsync(id);
            org.Name = input.Name;
            org.Code = input.Code;

            await _organizationRepository.UpdateAsync(org);

            ObjectMapper.Map<Organization, OrganizationDto>(org);
        }
    }
}
