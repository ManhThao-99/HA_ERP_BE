using Microsoft.Extensions.Localization;
using HA_ERP.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace HA_ERP;

[Dependency(ReplaceServices = true)]
public class HA_ERPBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<HA_ERPResource> _localizer;

    public HA_ERPBrandingProvider(IStringLocalizer<HA_ERPResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
