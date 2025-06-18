using Volo.Abp.Modularity;

namespace HA_ERP;

/* Inherit from this class for your domain layer tests. */
public abstract class HA_ERPDomainTestBase<TStartupModule> : HA_ERPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
