using HA_ERP.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace HA_ERP.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HA_ERPEntityFrameworkCoreModule),
    typeof(HA_ERPApplicationContractsModule)
    )]
public class HA_ERPDbMigratorModule : AbpModule
{
}
