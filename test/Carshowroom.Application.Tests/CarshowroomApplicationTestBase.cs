using Volo.Abp.Modularity;

namespace Carshowroom;

public abstract class CarshowroomApplicationTestBase<TStartupModule> : CarshowroomTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
