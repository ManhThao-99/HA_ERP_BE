using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HA_ERP.Staffs
{
    public class StaffDto : AuditedEntityDto<int>
    {
        public Guid? OrganizationUnitId { get; set; }
        public int? ManagerId { get; set; }
        public string Code { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? BankAccountName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }
    }
}
