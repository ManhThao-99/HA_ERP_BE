using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HA_ERP.Staffs
{
    public interface IStaffRepository : IRepository<Staff, int>
    {
        Task<List<Staff>> GetStaffsWithManagerRoleAsync(Guid id);
    }
}
