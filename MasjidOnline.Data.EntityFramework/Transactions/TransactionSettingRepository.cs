﻿using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Transaction;
using MasjidOnline.Entity.Transaction;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Transactions;

public class TransactionSettingRepository(TransactionDataContext _transactionDataContext) : ITransactionSettingRepository
{
    private readonly DbSet<TransactionSetting> _dbSet = _transactionDataContext.Set<TransactionSetting>();

    public async Task AddAsync(TransactionSetting transactionSetting)
    {
        await _dbSet.AddAsync(transactionSetting);
    }
}