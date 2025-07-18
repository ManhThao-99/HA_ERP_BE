using HA_ERP.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Volo.Abp;

namespace HA_ERP.SignalR
{
    public class OrganizationHub : Hub
    {
        private readonly IAuthorizationService _authorizationService;

        public OrganizationHub(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }


        //public async Task NotifyOrganizationChangedAsync(string action, int organizationId)
        //{
        //    var result = await _authorizationService.AuthorizeAsync(Context.User, HA_ERPPermissions.Organizations.Update);
        //    if (!result.Succeeded)
        //    {
        //        throw new BusinessException(HA_ERPDomainErrorCodes.RealtimePermissionDenied);
        //    }

        //    await Clients.Group(organizationId.ToString())
        //        .SendAsync("OrganizationChanged", action, organizationId);
        //}


        // Các hàm join/leave group không cần phân quyền đặc biệt
        public async Task JoinOrganizationGroup(int organizationId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, organizationId.ToString());
        }
        public async Task LeaveOrganizationGroup(int organizationId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, organizationId.ToString());
        }

      
    }
}
