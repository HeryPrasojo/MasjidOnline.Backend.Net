using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data;

public class DataTransaction : IDataTransaction
{
    private readonly List<IDataWithoutAudit> _datas = [];

    public async Task BeginAsync(params IDataWithoutAudit[] datas)
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
            await data.SaveAsync();
        }

        foreach (var data in _datas)
        {
            await data.CommitTransactionAsync();
        }

        _datas.Clear();
    }
}
