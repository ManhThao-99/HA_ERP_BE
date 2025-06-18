using HA_ERP.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HA_ERP.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HA_ERPController : AbpControllerBase
{
    protected HA_ERPController()
    {
        LocalizationResource = typeof(HA_ERPResource);
    }
}
