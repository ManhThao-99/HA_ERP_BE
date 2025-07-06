using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA_ERP.Organizations
{
    public interface IOrganizationNotifier
    {
        Task NotifyOrganizationChangedAsync(string action, int organizationId);
    }
}
