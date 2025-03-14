using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Data;

public class DataTransaction(IAuditData _auditData) : IDataTransaction
{
    private readonly List<IData> _datas = [];

    public async Task BeginAsync(params IData[] datas)
    {
        foreach (var data in datas)
            await data.BeginTransactionAsync();

        _datas.AddRange(datas);


        var anyDataWithAudit = datas.Any(d => d is IDataWithAudit);

        if (anyDataWithAudit)
        {
            anyDataWithAudit = _datas.Any(d => d is IDataWithAudit);

            if (!anyDataWithAudit)
            {
                await _auditData.BeginTransactionAsync();

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


        var anyDataWithAudit = _datas.Any(d => d is IDataWithAudit);

        if (anyDataWithAudit) await _auditData.CommitTransactionAsync();


        foreach (var data in _datas)
            await data.CommitTransactionAsync();


        _datas.Clear();
    }
}
