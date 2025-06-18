using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace HA_ERP.Organizations
{
    public class OrganizationManager : DomainService
    {
        private readonly IOrganizationRepository  _organizationRepository;

        public OrganizationManager(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }
    }
}
