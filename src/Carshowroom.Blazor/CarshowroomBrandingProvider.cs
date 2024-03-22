using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Carshowroom.Blazor;

[Dependency(ReplaceServices = true)]
public class CarshowroomBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Carshowroom";
}
