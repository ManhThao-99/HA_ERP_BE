using Volo.Abp.Settings;

namespace HA_ERP.Settings;

public class HA_ERPSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(HA_ERPSettings.MySetting1));
    }
}
