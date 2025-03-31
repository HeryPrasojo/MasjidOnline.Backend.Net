﻿using System.Threading.Tasks;
using MasjidOnline.Entity.Authorization;

namespace MasjidOnline.Data.Interface.Repository.Authorization;

public interface IAuthorizationSettingRepository
{
    Task AddAsync(AuthorizationSetting authorizationSetting);
}
