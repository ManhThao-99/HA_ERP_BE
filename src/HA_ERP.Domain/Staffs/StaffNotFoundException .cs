using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace HA_ERP.Staffs
{
    public class StaffNotFoundException : BusinessException
    {
        public StaffNotFoundException(int staffId)
            : base(HA_ERPDomainErrorCodes.StaffNotFound)
        {
            WithData("StaffId", staffId);
        }
        public StaffNotFoundException(string staffName)
            : base(HA_ERPDomainErrorCodes.StaffNotFound)
        {
            WithData("staffName", staffName);
        }
        // You can add more constructors if needed for different scenarios
    }
}
