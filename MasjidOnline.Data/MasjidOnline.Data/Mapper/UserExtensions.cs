using System;
using MasjidOnline.Entity.Audit;
using MasjidOnline.Entity.User;

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
            EmailAddress = user.EmailAddress,
            Name = user.Name,
            Password = user.Password,
            Type = user.Type,
        };
    }
}
