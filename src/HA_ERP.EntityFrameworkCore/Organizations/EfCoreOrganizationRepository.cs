using HA_ERP.EntityFrameworkCore;
using HA_ERP.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace HA_ERP.Organizations
{
    public class EfCoreOrganizationRepository : EfCoreRepository<HA_ERPDbContext, Organization, int>,
         IOrganizationRepository
    {
        public EfCoreOrganizationRepository(IDbContextProvider<HA_ERPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

    }
}
