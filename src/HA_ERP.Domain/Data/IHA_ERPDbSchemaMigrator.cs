using System.Threading.Tasks;

namespace HA_ERP.Data;

public interface IHA_ERPDbSchemaMigrator
{
    Task MigrateAsync();
}
