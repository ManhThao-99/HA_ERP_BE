namespace HA_ERP.Permissions;

public static class HA_ERPPermissions
{
    public const string GroupName = "HA_ERP";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";


    public static class Staffs
    {
        public const string Default = GroupName + ".Staffs";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string View = Default + ".View";
    }

   

}
