using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Carshowroom.Data;
using Volo.Abp.DependencyInjection;

namespace Carshowroom.EntityFrameworkCore;

public class EntityFrameworkCoreCarshowroomDbSchemaMigrator
    : ICarshowroomDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCarshowroomDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the CarshowroomDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CarshowroomDbContext>()
            .Database
            .MigrateAsync();
    }
}
