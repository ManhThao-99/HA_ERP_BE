using HA_ERP.SignalR;
using HA_ERP.Staffs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace HA_ERP.Controllers
{
    [Route("api/staffs")]
    public class StaffController : AbpController
    {
        private readonly IStaffAppService _staffAppService;
        private readonly IHubContext<StaffHub> _hubContext;

        public StaffController(IStaffAppService staffAppService, IHubContext<StaffHub> hubContext)
        {
            _staffAppService = staffAppService;
            _hubContext = hubContext;
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, UpdateStaffDto input)
        //{
        //    await _staffAppService.UpdateAsync(id, input);
        //    await _hubContext.Clients.All.SendAsync("StaffChanged", new { action = "update", staffId = id });
        //    return NoContent();
        //}
    }
}
