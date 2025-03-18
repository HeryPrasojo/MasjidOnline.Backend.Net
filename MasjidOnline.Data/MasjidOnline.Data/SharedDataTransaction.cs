using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data;

public class SharedDataTransaction(IAuditData _auditData) : IDataTransaction
{
    private readonly List<IData> _datas = [];

    private object? _transactionObject;

    public async Task BeginAsync(params IData[] datas)
    {
        if (_datas.Count == default)
        {
            var firstData = datas.First();

            await firstData.BeginTransactionAsync();

            _transactionObject = firstData.TransactionObject;

            foreach (var data in datas.Skip(1))
                await data.UseTransactionAsync(_transactionObject);
        }
        else
        {
            foreach (var data in datas)
                await data.UseTransactionAsync(_transactionObject);
        }

        _datas.AddRange(datas);
    }

    public async Task CommitAsync()
    {
        _datas.Reverse();

        foreach (var data in _datas)
            await data.SaveAsync();

        await _datas[0].CommitTransactionAsync();

        _datas.Clear();
    }
}
