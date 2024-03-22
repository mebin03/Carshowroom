using Volo.Abp.Settings;

namespace Carshowroom.Settings;

public class CarshowroomSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CarshowroomSettings.MySetting1));
    }
}
