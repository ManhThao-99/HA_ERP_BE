//using Microsoft.AspNetCore.SignalR;
//using System.Threading.Tasks;

//namespace HA_ERP.SignalR
//{
//    public class OrganizationSignalRNotifier : IOrganizationNotifier
//    {
//        private readonly IHubContext<OrganizationHub> _hubContext;

//        public OrganizationSignalRNotifier(IHubContext<OrganizationHub> hubContext)
//        {
//            _hubContext = hubContext;
//        }

//        public async Task NotifyOrganizationChangedAsync(string action, int organizationId)
//        {
//            await _hubContext.Clients.Group(organizationId.ToString())
//                .SendAsync("OrganizationChanged", action, organizationId);
//        }
//    }
//}
