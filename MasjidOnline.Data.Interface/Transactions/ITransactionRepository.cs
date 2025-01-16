﻿using System.Threading.Tasks;
using MasjidOnline.Entity.Transactions;

namespace MasjidOnline.Data.Interface.Transactions;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
    Task<int> AddAndSaveAsync(Transaction transaction);
    Task<int> GetMaxIdAsync();
}
