using HA_ERP.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace HA_ERP.Staffs
{
    public class EfCoreStaffRepository : EfCoreRepository<HA_ERPDbContext, Staff, int>,
        IStaffRepository
    {
        public EfCoreStaffRepository(IDbContextProvider<HA_ERPDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

   
    }
}
