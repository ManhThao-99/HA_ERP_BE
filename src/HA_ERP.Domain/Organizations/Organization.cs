using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HA_ERP.Organizations
{
    public class Organization : FullAuditedAggregateRoot<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Organization()
        {
            
        }

        public Organization(int id, string code, string name) : base(id)
        {
            Code = code;
            Name = name;
        }
    }
}
