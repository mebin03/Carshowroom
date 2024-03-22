using System.Threading.Tasks;

namespace Carshowroom.Data;

public interface ICarshowroomDbSchemaMigrator
{
    Task MigrateAsync();
}
