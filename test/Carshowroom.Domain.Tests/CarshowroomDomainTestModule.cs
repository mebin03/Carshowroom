using Volo.Abp.Modularity;

namespace Carshowroom;

[DependsOn(
    typeof(CarshowroomDomainModule),
    typeof(CarshowroomTestBaseModule)
)]
public class CarshowroomDomainTestModule : AbpModule
{

}
