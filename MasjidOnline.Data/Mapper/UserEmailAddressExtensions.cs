using System;
using MasjidOnline.Entity.Audit;
using MasjidOnline.Entity.Users;

namespace MasjidOnline.Data.Mapper;

public static class UserEmailAddressExtensions
{
    public static UserEmailAddressLog MapUserEmailAddressLog(this UserEmailAddress userEmailAddress, int userEmailAddressLogId, int sessionUserId, DateTime dateTime)
    {
        return new UserEmailAddressLog
        {
            UserEmailAddressLogId = userEmailAddressLogId,
            SessionUserId = sessionUserId,
            DateTime = dateTime,

            Id = userEmailAddress.Id,
            EmailAddress = userEmailAddress.EmailAddress,
            UserId = userEmailAddress.UserId,
        };
    }
}
