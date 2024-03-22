using Carshowroom.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Carshowroom.Blazor;

public abstract class CarshowroomComponentBase : AbpComponentBase
{
    protected CarshowroomComponentBase()
    {
        LocalizationResource = typeof(CarshowroomResource);
    }
}
