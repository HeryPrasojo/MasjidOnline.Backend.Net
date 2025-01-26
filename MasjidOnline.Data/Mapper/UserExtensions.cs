using System;
using MasjidOnline.Entity.Audit;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Mapper;

public static class UserExtensions
{
    public static UserLog MapUserLog(this User user, int userLogId, int sessionUserId, DateTime dateTime)
    {
        return new UserLog
        {
            UserLogId = userLogId,
            SessionUserId = sessionUserId,
            DateTime = dateTime,

            Id = user.Id,
            EmailAddressId = user.EmailAddressId,
            Name = user.Name,
            Password = user.Password,
            UserType = user.UserType,
        };
    }
}
