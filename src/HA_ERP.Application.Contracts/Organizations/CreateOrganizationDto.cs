using HA_ERP.Organizstions;
using HA_ERP.Staffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA_ERP.Organizations
{
    public class CreateOrganizationDto
    {
        [Required(ErrorMessage = "Org:CodeRequired")]
        [StringLength(OrganizationConsts.MaxCodeLength, ErrorMessage = "Org:CodeLength")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Org:NameRequired")]
        [StringLength(OrganizationConsts.MaxCodeLength, ErrorMessage = "Org:NameLength")]

        public string Name { get; set; }
    }
}
