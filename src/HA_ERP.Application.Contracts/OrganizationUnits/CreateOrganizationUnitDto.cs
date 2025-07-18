using System;
using System.ComponentModel.DataAnnotations;

namespace HA_ERP.OrganizationUnits
{
    public class CreateOrganizationUnitDto
    {
        [Required]
        public string DisplayName { get; set; }

        public Guid? ParentId { get; set; }
     
    }
}