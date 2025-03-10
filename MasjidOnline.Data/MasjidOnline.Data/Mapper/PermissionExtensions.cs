using System;
using MasjidOnline.Entity.Audit;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Mapper;

public static class PermissionExtensions
{
    public static PermissionLog MapPermissionLog(this Permission permission, int permissionLogId, int sessionUserId, DateTime dateTime)
    {
        return new PermissionLog
        {
            PermissionLogId = permissionLogId,
            SessionUserId = sessionUserId,
            DateTime = dateTime,

            UserId = permission.UserId,
            InfaqExpireAdd = permission.InfaqExpireAdd,
            InfaqExpireApprove = permission.InfaqExpireApprove,
            InfaqExpireCancel = permission.InfaqExpireCancel,
            InfaqSuccessAdd = permission.InfaqSuccessAdd,
            InfaqSuccessApprove = permission.InfaqSuccessApprove,
            InfaqSuccessCancel = permission.InfaqSuccessCancel,
            InfaqVoidAdd = permission.InfaqVoidAdd,
            InfaqVoidApprove = permission.InfaqVoidApprove,
            InfaqVoidCancel = permission.InfaqVoidCancel,
            UserInternalAdd = permission.UserInternalAdd,
            UserInternalApprove = permission.UserInternalApprove,
            UserInternalCancel = permission.UserInternalCancel,
        };
    }
}
