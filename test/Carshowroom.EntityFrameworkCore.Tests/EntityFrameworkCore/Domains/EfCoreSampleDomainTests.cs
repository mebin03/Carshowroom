using Carshowroom.Samples;
using Xunit;

namespace Carshowroom.EntityFrameworkCore.Domains;

[Collection(CarshowroomTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<CarshowroomEntityFrameworkCoreTestModule>
{

}
