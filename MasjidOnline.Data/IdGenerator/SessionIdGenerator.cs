﻿using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerator;

public class SessionIdGenerator() : ISessionsIdGenerator
{

    public async Task InitializeAsync(ISessionsData sessionData)
    {
        await Task.CompletedTask;
    }
}
