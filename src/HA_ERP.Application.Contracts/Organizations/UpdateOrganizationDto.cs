using HA_ERP.Organizstions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA_ERP.Organizations
{
    public class UpdateOrganizationDto
    {
        [Required]
        [StringLength(OrganizationConsts.MaxCodeLength)]
        public string Code { get; set; }
        [Required]
        [StringLength(OrganizationConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
