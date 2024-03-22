using Carshowroom.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Carshowroom.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CarshowroomController : AbpControllerBase
{
    protected CarshowroomController()
    {
        LocalizationResource = typeof(CarshowroomResource);
    }
}
