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

        var organizationsPermission = myGroup.AddPermission(HA_ERPPermissions.Organizations.Default, L("Permission:Organizations"));
        organizationsPermission.AddChild(HA_ERPPermissions.Organizations.Create, L("Permission:Organizations.Create"));
        organizationsPermission.AddChild(HA_ERPPermissions.Organizations.Update, L("Permission:Organizations.Update"));
        organizationsPermission.AddChild(HA_ERPPermissions.Organizations.Delete, L("Permission:Organizations.Delete"));

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
