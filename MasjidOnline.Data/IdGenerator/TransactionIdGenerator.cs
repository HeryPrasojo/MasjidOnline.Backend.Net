using System;
using System.Threading;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.IdGenerator;

public class TransactionIdGenerator : ITransactionIdGenerator
{
    private long _transactionId;

    public TransactionIdGenerator(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var coreData = serviceScope.ServiceProvider.GetService<ITransactionData>()
            ?? throw new ApplicationException($"Get ITransactionData service fail");
    }

    public long TransactionId => Interlocked.Increment(ref _transactionId);
}
