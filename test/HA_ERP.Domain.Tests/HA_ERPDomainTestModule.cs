using Volo.Abp.Modularity;

namespace HA_ERP;

[DependsOn(
    typeof(HA_ERPDomainModule),
    typeof(HA_ERPTestBaseModule)
)]
public class HA_ERPDomainTestModule : AbpModule
{

}
