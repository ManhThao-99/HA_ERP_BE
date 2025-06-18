using System;
using System.Collections.Generic;
using System.Text;
using HA_ERP.Localization;
using Volo.Abp.Application.Services;

namespace HA_ERP;

/* Inherit your application services from this class.
 */
public abstract class HA_ERPAppService : ApplicationService
{
    protected HA_ERPAppService()
    {
        LocalizationResource = typeof(HA_ERPResource);
    }
}
