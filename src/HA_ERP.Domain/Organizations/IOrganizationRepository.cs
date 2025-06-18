using HA_ERP.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HA_ERP.Organizations
{
    public interface IOrganizationRepository : IRepository<Organization, int>
    {
    }
}
