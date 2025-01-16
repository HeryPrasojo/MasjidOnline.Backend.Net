using System;
using System.Threading;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.IdGenerator;

public class TransactionIdGenerator : ITransactionIdGenerator
{
    private long _transactionId;
    private long _transactionFileId;

    public TransactionIdGenerator(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var transactionData = serviceScope.ServiceProvider.GetService<ITransactionData>()
            ?? throw new ApplicationException($"Get ITransactionData service fail");

        _transactionId = transactionData.Transaction.GetMaxIdAsync().Result;

        _transactionFileId = transactionData.TransactionFile.GetMaxIdAsync().Result;
    }

    public long TransactionId => Interlocked.Increment(ref _transactionId);

    public long TransactionFileId => Interlocked.Increment(ref _transactionFileId);
}
