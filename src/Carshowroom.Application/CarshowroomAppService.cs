using System;
using System.Collections.Generic;
using System.Text;
using Carshowroom.Localization;
using Volo.Abp.Application.Services;

namespace Carshowroom;

/* Inherit your application services from this class.
 */
public abstract class CarshowroomAppService : ApplicationService
{
    protected CarshowroomAppService()
    {
        LocalizationResource = typeof(CarshowroomResource);
    }
}
