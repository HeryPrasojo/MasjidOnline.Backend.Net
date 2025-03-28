﻿using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.Interface;

public interface IIdGenerator
{
    IAuditIdGenerator Audit { get; }
    IPersonIdGenerator Person { get; }
    ICaptchaIdGenerator Captcha { get; }
    IEventIdGenerator Event { get; }
    IInfaqIdGenerator Infaq { get; }
    ISessionIdGenerator Session { get; }
    IUserIdGenerator User { get; }
}
