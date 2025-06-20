using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace HA_ERP.Staffs
{
    public class StaffManager : DomainService
    {
        private readonly IStaffRepository _staffRepository;

        public StaffManager(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public async Task<Staff> GetStaffOrThrowAsync(int id)
        {
            var staff = await _staffRepository.FindAsync(id);
            if (staff == null)
            {
                throw new StaffNotFoundException(id);
            }
            return staff;
        }

        public async Task CheckStaffNameExistsAsync(string name, int exceptId = 0)
        {
            var exists = await _staffRepository.AnyAsync(x => x.Name == name && x.Id != exceptId);
            if (exists)
            {
                throw new StaffAlreadyExistsException(name);
            }
        }
    }
}
