using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data;

public class DataTransaction(ISessionBusiness _sessionBusiness) : IDataTransaction
{
    private readonly List<IData> _datas = [];

    public async Task BeginAsync(params IData[] datas)
    {
        foreach (var data in datas)
        {
            await data.BeginTransactionAsync();
        }

        _datas.AddRange(datas);
    }

    public async Task CommitAsync()
    {
        foreach (var data in _datas)
        {
            if (data is IDataWithAudit dataWithAudit) await dataWithAudit.SaveAsync(_sessionBusiness.UserId);
            else if (data is IDataWithoutAudit dataWithoutAudit) await dataWithoutAudit.SaveAsync();
        }

        foreach (var data in _datas)
        {
            await data.CommitTransactionAsync();
        }

        _datas.Clear();
    }
}
