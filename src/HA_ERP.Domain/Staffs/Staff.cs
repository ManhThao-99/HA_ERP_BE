﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace HA_ERP.Staffs
{
    public class Staff : FullAuditedAggregateRoot<int>
    {
        public Guid? OrganizationUnitId { get; set; }
        public int? ManagerId { get; set; }
        public Guid? UserId { get; set; }
        public string Code { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? BankAccountName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }

        public Staff()
        {
            
        }

        public Staff(Guid? organizationUnitId, int? managerId, Guid? userId, string code, string? name, string? mobile, string? email, string? address, string? bankAccountName, string? bankAccountNo, string? bankName, string? bankAddress)
        {
            OrganizationUnitId = organizationUnitId;
            ManagerId = managerId;
            UserId = userId;
            Code = code;
            Name = name;
            Mobile = mobile;
            Email = email;
            Address = address;
            BankAccountName = bankAccountName;
            BankAccountNo = bankAccountNo;
            BankName = bankName;
            BankAddress = bankAddress;
        }
    }
   

}
