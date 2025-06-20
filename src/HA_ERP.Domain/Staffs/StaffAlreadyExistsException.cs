using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace HA_ERP.Staffs
{
    public class StaffAlreadyExistsException : BusinessException
    {
        public StaffAlreadyExistsException(string name)
            : base(HA_ERPDomainErrorCodes.StaffAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
