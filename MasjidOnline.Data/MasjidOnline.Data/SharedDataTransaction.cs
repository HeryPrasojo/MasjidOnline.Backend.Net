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


        var anyDataWithAudit = datas.Any(d => d is IDataWithAudit);

        if (anyDataWithAudit)
        {
            anyDataWithAudit = _datas.Any(d => d is IDataWithAudit);

            if (!anyDataWithAudit)
            {
                await _auditData.UseTransactionAsync(_transactionObject);

                _datas.Add(_auditData);
            }
        }
    }

    public async Task CommitAsync(int userId)
    {
        _datas.Reverse();

        foreach (var data in _datas)
        {
            if (data is IDataWithAudit dataWithAudit) await dataWithAudit.SaveWithoutTransactionAsync(userId);
            else if (data is IDataWithoutAudit dataWithoutAudit) await dataWithoutAudit.SaveAsync();
        }

        await _datas[0].CommitTransactionAsync();

        _datas.Clear();
    }
}
