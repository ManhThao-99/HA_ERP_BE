using System;
using System.Collections.Generic;

namespace HA_ERP.OrganizationUnits
{
    public class OrganizationUnitTreeDto
    {
        public Guid Id { get; set; }
        public string DisplayName { get; set; }
        public Guid? ParentId { get; set; }
        public List<OrganizationUnitTreeDto> Children { get; set; } = new List<OrganizationUnitTreeDto>();
    }
}