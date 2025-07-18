using System;
using System.ComponentModel.DataAnnotations;

namespace HA_ERP.OrganizationUnits
{
    public class UpdateOrganizationUnitDto
    {
        [Required]
        public string DisplayName { get; set; }

        public Guid? ParentId { get; set; }
    }
}