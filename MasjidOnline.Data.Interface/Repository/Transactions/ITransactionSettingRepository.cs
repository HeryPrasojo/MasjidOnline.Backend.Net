﻿using System.Threading.Tasks;
using MasjidOnline.Entity.Transactions;

namespace MasjidOnline.Data.Interface.Repository.Transactions;

public interface ITransactionSettingRepository
{
    Task AddAsync(TransactionSetting setting);
}
