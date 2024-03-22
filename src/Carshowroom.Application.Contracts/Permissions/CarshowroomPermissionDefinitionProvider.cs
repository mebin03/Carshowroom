using Carshowroom.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Carshowroom.Permissions
{
    public class CarshowroomPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var carshowroomGroup= context.AddGroup(CarshowroomPermissions.GroupName, L("Permission:Carshowroom"));
            var carsPermission = carshowroomGroup.AddPermission(CarshowroomPermissions.Cars.Default, L("Permission:Cars"));
            carsPermission.AddChild(CarshowroomPermissions.Cars.Create, L("Permission:Cars.Create"));
            carsPermission.AddChild(CarshowroomPermissions.Cars.Edit, L("Permission:Cars.Edit"));
            carsPermission.AddChild(CarshowroomPermissions.Cars.Delete, L("Permission:Cars.Delete"));

            var brandsPermission = carshowroomGroup.AddPermission(
    CarshowroomPermissions.Brands.Default, L("Permission:Brands"));
            brandsPermission.AddChild(
                CarshowroomPermissions.Brands.Create, L("Permission:Brands.Create"));
            brandsPermission.AddChild(
                CarshowroomPermissions.Brands.Edit, L("Permission:Brands.Edit"));
           brandsPermission.AddChild(
                CarshowroomPermissions.Brands.Delete, L("Permission:Brands.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CarshowroomResource>(name);
        }
    }
}
