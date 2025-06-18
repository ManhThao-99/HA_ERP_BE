using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HA_ERP.Data;
using Volo.Abp.DependencyInjection;

namespace HA_ERP.EntityFrameworkCore;

public class EntityFrameworkCoreHA_ERPDbSchemaMigrator
    : IHA_ERPDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreHA_ERPDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the HA_ERPDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<HA_ERPDbContext>()
            .Database
            .MigrateAsync();
    }
}
