using Carshowroom.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Carshowroom.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CarshowroomEntityFrameworkCoreModule),
    typeof(CarshowroomApplicationContractsModule)
    )]
public class CarshowroomDbMigratorModule : AbpModule
{
}
