using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Carshowroom.Data;

/* This is used if database provider does't define
 * ICarshowroomDbSchemaMigrator implementation.
 */
public class NullCarshowroomDbSchemaMigrator : ICarshowroomDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
