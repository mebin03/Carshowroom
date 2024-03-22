using Carshowroom.Permissions;
using Carshowroom.Localization;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Carshowroom.Blazor.Menus;

public class CarshowroomMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<CarshowroomResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                "Carshowroom.Home",
                l["Menu:Home"],
                "/",
                icon: "fas fa-home"
            )
        );

        var carshowroomMenu = new ApplicationMenuItem(
            "Carshowroom",
            l["Menu:Carshowroom"],
            icon: "fas fa-store"
        );

        context.Menu.AddItem(carshowroomMenu);

        //CHECK the PERMISSION
        if (await context.IsGrantedAsync(CarshowroomPermissions.Cars.Default))
        {
            carshowroomMenu.AddItem(new ApplicationMenuItem(
                "Carshowroom.Cars",
                l["Menu:Cars"],
                icon: "fas fa-car",
                url: "/cars"

            ));
        }

        if (await context.IsGrantedAsync(CarshowroomPermissions.Brands.Default))
        {
            carshowroomMenu.AddItem(new ApplicationMenuItem(
                "Carshowroom.Brands",
                l["Menu:Brands"],
                url: "/brands"
            ));
        }

    }
}
