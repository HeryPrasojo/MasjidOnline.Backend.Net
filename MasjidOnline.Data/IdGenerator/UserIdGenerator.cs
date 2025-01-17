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

        var transactionData = serviceScope.ServiceProvider.GetService<IUserData>()
            ?? throw new ApplicationException($"Get IUserData service fail");

        _userId = transactionData.User.GetMaxIdAsync().Result;

        _userEmailAddressId = transactionData.UserEmailAddress.GetMaxIdAsync().Result;
    }

    public int UserId => Interlocked.Increment(ref _userId);

    public int UserEmailAddressId => Interlocked.Increment(ref _userEmailAddressId);
}
