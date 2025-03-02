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
            UserAddInternal = permission.UserAddInternal,
            InfaqSetPaymentStatusExpired = permission.InfaqSetPaymentStatusExpired,
        };
    }
}
