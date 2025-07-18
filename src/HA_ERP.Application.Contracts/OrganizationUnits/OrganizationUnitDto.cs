using System;
using Volo.Abp.Application.Dtos;

namespace HA_ERP.OrganizationUnits
{
    public class OrganizationUnitDto : EntityDto<Guid>
    {
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public Guid? ParentId { get; set; }
        public int? ChildrenCount { get; set; } // Nếu muốn trả về số lượng con
        // Thêm các trường khác nếu cần
    }
}