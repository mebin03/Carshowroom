using Carshowroom.Samples;
using Xunit;

namespace Carshowroom.EntityFrameworkCore.Applications;

[Collection(CarshowroomTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<CarshowroomEntityFrameworkCoreTestModule>
{

}
