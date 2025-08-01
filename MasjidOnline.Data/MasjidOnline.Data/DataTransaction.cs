using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data;

public class DataTransaction : IDataTransaction
{
    private readonly List<IDatabase> _datas = [];

    public async Task BeginAsync(params IDatabase[] datas)
    {
        foreach (var data in datas)
            await data.BeginTransactionAsync();

        _datas.AddRange(datas);
    }

    public async Task CommitAsync()
    {
        _datas.Reverse();

        foreach (var data in _datas)
            await data.SaveAsync();

        foreach (var data in _datas)
            await data.CommitTransactionAsync();

        _datas.Clear();
    }

    public async Task RollbackAsync()
    {
        _datas.Reverse();

        foreach (var data in _datas)
            await data.RolbackTransactionAsync();

        _datas.Clear();
    }
}
