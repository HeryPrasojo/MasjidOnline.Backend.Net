﻿using System.Threading.Tasks;
using MasjidOnline.Entity.Audit;

namespace MasjidOnline.Data.Interface.Repository.Audit;

public interface IAuditSettingRepository
{
    Task AddAsync(AuditSetting auditSetting);
}
