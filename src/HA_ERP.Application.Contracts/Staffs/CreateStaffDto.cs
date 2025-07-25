﻿using System;
using System.ComponentModel.DataAnnotations;

namespace HA_ERP.Staffs
{
    public class CreateStaffDto
    {
        public Guid? OrganizationUnitId { get; set; }
        public int? ManagerId { get; set; }
        [Required]
        [StringLength(StaffConsts.MaxCodeLength)]
        public string Code { get; set; }

        [StringLength(StaffConsts.MaxNameLength)]
        public string? Name { get; set; }
        [StringLength(StaffConsts.MaxMobileLength)]
        public string? Mobile { get; set; }

        [StringLength(StaffConsts.MaxEmailLength)]
        public string? Email { get; set; }

        [StringLength(StaffConsts.MaxAddressLength)]
        public string? Address { get; set; }

        [StringLength(StaffConsts.MaxBankAccountNameLength)]
        public string? BankAccountName { get; set; }
        [StringLength(StaffConsts.MaxBankAccountNoLength)]
        public string? BankAccountNo { get; set; }
        [StringLength(StaffConsts.MaxBankNameLength)]
        public string? BankName { get; set; }
        [StringLength(StaffConsts.MaxBankAddressLength)]
        public string? BankAddress { get; set; }


    }
}
