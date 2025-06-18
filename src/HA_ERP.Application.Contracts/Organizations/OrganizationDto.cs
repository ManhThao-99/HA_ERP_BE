using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HA_ERP.Organizations
{
    public class OrganizationDto : EntityDto<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
