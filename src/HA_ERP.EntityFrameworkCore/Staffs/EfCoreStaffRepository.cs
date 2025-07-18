using HA_ERP.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Staff>> GetStaffsWithManagerRoleAsync(Guid id)
        {
            var dbContext = await GetDbContextAsync();

            // Lấy Id của role "Manager"
            var managerRoleId = await dbContext.Roles
                .Where(r => r.Name == "Manager")
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            if (managerRoleId == Guid.Empty)
            {
                return new List<Staff>();
            }

            // Join Staff - User - UserRole - Role
            var staffs = await (
                from staff in dbContext.Staffs
                join user in dbContext.Users on staff.UserId equals user.Id
                join userRole in dbContext.UserRoles on user.Id equals userRole.UserId
                where userRole.RoleId == managerRoleId && staff.OrganizationUnitId == id
                select staff
            ).ToListAsync();

            return staffs;
        }
    }
}
