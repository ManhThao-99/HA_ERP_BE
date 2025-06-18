using Volo.Abp.Modularity;

namespace HA_ERP;

[DependsOn(
    typeof(HA_ERPApplicationModule),
    typeof(HA_ERPDomainTestModule)
)]
public class HA_ERPApplicationTestModule : AbpModule
{

}
