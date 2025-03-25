using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data;

public class SharedDataTransaction : IDataTransaction
{
    private readonly List<IDatabase> _datas = [];

    public async Task BeginAsync(params IDatabase[] datas)
    {
    }

    public async Task CommitAsync()
    {
    }
}
