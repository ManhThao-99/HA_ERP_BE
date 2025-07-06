using HA_ERP.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace HA_ERP.Organizations
{
    public class OrganizationManager : DomainService
    {
        private readonly IOrganizationRepository  _organizationRepository;

        private readonly IStaffRepository _staffRepository;

        public OrganizationManager(IOrganizationRepository organizationRepository, IStaffRepository staffRepository)
        {
            _organizationRepository = organizationRepository;
            _staffRepository = staffRepository;
        }

        public async Task CheckDuplicateAsync(string name, string code, int? exceptId = null)
        {
            var existCode = await _organizationRepository.AnyAsync(
         x => x.Code == code && (!exceptId.HasValue || x.Id != exceptId.Value)
     );
            HA_ERPValidationHelper.ThrowIfExists(existCode);

            var existName = await _organizationRepository.AnyAsync(
                x => x.Name == name && (!exceptId.HasValue || x.Id != exceptId.Value)
            );
            HA_ERPValidationHelper.ThrowIfExists(existName);
        }

        public async Task CheckNotFoundAsync(int id)
        {
            var org = await _organizationRepository.FindAsync(id);
            HA_ERPValidationHelper.ThrowIfNotFound(org);
        }

        public async Task CheckHasStaffAsync(int organizationId)
        {
            var hasStaff = await _staffRepository.AnyAsync(s => s.OrganizationId == organizationId);
            if (hasStaff)
                throw new BusinessException(HA_ERPDomainErrorCodes.OrganizationHasStaff);
        }


    }
}
