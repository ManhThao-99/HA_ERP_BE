using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA_ERP.Staffs
{
    public class CreateStaffDto
    {
        [Required]
        public int OrganizationId { get; set; }
        public int? ManagerId { get; set; }
        [Required]
        [StringLength(StaffConsts.MaxCodeLength)]
        public string Code { get; set; }
        [Required]
        [StringLength(StaffConsts.MaxNameLength)]
        public string Name { get; set; }
        [Required]
        [StringLength(StaffConsts.MaxMobileLength)]
        public string Mobile { get; set; }
        [Required]
        [StringLength(StaffConsts.MaxEmailLength)]
        public string Email { get; set; }
        [Required]
        [StringLength(StaffConsts.MaxAddressLength)]
        public string Address { get; set; }
        [Required]
        [StringLength(StaffConsts.MaxBankAccountNameLength)]
        public string BankAccountName { get; set; }
        [Required]
        [StringLength(StaffConsts.MaxBankAccountNoLength)]
        public string BankAccountNo { get; set; }
        [Required]
        [StringLength(StaffConsts.MaxBankNameLength)]
        public string BankName { get; set; }
        [Required]
        [StringLength(StaffConsts.MaxBankAddressLength)]
        public string BankAddress { get; set; }

    }
}
