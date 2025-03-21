﻿using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ISessionIdGenerator
{
    byte[] SessionDigest { get; }
    int SessionId { get; }

    Task InitializeAsync(ISessionData sessionData);
}
