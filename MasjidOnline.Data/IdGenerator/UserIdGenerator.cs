using System;
using System.Threading;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.IdGenerator;

public class UserIdGenerator : IUserIdGenerator
{
    private int _userId;
    private int _userEmailAddressId;

    public UserIdGenerator(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var userData = serviceScope.ServiceProvider.GetService<IUserData>()
            ?? throw new ApplicationException($"Get IUserData service fail");

        _userId = userData.User.GetMaxIdAsync().Result;

        _userEmailAddressId = userData.UserEmailAddress.GetMaxIdAsync().Result;
    }

    public int UserId => Interlocked.Increment(ref _userId);

    public int UserEmailAddressId => Interlocked.Increment(ref _userEmailAddressId);
}
