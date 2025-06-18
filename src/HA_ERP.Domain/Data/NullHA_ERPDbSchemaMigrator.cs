using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HA_ERP.Data;

/* This is used if database provider does't define
 * IHA_ERPDbSchemaMigrator implementation.
 */
public class NullHA_ERPDbSchemaMigrator : IHA_ERPDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
