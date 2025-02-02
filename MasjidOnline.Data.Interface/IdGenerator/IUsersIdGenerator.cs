﻿using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IUsersIdGenerator
{
    int UserId { get; }
    int UserEmailAddressId { get; }

    Task InitializeAsync(IUsersData userData);
}
