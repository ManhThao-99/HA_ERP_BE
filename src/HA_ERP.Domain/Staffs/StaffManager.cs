using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
