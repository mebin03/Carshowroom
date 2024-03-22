namespace Carshowroom.Permissions;

public static class CarshowroomPermissions
{
    public const string GroupName = "Carshowroom";

    public static class Cars
    {
        public const string Default = GroupName + ".Cars";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class Brands
    {
        public const string Default = GroupName + ".Brands";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
