using HA_ERP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HA_ERP.Permissions;

public class HA_ERPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(HA_ERPPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(HA_ERPPermissions.MyPermission1, L("Permission:MyPermission1"));

      

        var staffsPermission = myGroup.AddPermission(HA_ERPPermissions.Staffs.Default, L("Permission:Staffs"));
        staffsPermission.AddChild(HA_ERPPermissions.Staffs.Create, L("Permission:Staffs.Create"));
        staffsPermission.AddChild(HA_ERPPermissions.Staffs.Update, L("Permission:Staffs.Update"));
        staffsPermission.AddChild(HA_ERPPermissions.Staffs.Delete, L("Permission:Staffs.Delete"));



    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<HA_ERPResource>(name);
    }
}
