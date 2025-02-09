using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data;

public class DataTransaction : IDataTransaction
{
    public async Task BeginAsync(params IData[] datas)
    {
        foreach (var data in datas)
        {
            await data.BeginTransactionAsync();
        }
    }

    public async Task CommitAsync(params IData[] datas)
    {
        foreach (var data in datas)
        {
            await data.CommitTransactionAsync();
        }
    }
}
