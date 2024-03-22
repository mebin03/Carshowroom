using Volo.Abp.Modularity;

namespace Carshowroom;

[DependsOn(
    typeof(CarshowroomApplicationModule),
    typeof(CarshowroomDomainTestModule)
)]
public class CarshowroomApplicationTestModule : AbpModule
{

}
