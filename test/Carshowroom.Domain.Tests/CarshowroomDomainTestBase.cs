using Volo.Abp.Modularity;

namespace Carshowroom;

/* Inherit from this class for your domain layer tests. */
public abstract class CarshowroomDomainTestBase<TStartupModule> : CarshowroomTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
