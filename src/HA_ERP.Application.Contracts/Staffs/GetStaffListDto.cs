using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace HA_ERP.Staffs
{
    public class GetStaffListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
