using Volo.Abp.Modularity;

namespace HA_ERP;

public abstract class HA_ERPApplicationTestBase<TStartupModule> : HA_ERPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
