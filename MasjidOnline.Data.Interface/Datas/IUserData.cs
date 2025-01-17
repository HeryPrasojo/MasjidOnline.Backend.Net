﻿using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Users;

namespace MasjidOnline.Data.Interface.Datas;

public interface IUserData
{
    IUserRepository User { get; }
    IUserEmailAddressRepository UserEmailAddress { get; }
    IUserSettingRepository UserSetting { get; }

    Task SaveAsync();
}
