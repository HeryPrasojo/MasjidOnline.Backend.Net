using System;
using System.Threading;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.IdGenerator;

public class TransactionIdGenerator : ITransactionIdGenerator
{
    private int _transactionId;
    private int _transactionFileId;

    public TransactionIdGenerator(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var transactionData = serviceScope.ServiceProvider.GetService<ITransactionData>()
            ?? throw new ApplicationException($"Get ITransactionData service fail");

        _transactionId = transactionData.Transaction.GetMaxIdAsync().Result;

        _transactionFileId = transactionData.TransactionFile.GetMaxIdAsync().Result;
    }

    public int TransactionId => Interlocked.Increment(ref _transactionId);

    public int TransactionFileId => Interlocked.Increment(ref _transactionFileId);
}
