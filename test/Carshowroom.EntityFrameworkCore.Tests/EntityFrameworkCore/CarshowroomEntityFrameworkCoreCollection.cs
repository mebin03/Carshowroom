using Xunit;

namespace Carshowroom.EntityFrameworkCore;

[CollectionDefinition(CarshowroomTestConsts.CollectionDefinitionName)]
public class CarshowroomEntityFrameworkCoreCollection : ICollectionFixture<CarshowroomEntityFrameworkCoreFixture>
{

}
