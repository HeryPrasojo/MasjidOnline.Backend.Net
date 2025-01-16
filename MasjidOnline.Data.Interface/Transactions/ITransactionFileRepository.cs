﻿using System.Threading.Tasks;
using MasjidOnline.Entity.Transactions;

namespace MasjidOnline.Data.Interface.Transactions;

public interface ITransactionFileRepository
{
    Task AddAsync(TransactionFile transactionFile);
    Task<int> GetMaxIdAsync();
}
