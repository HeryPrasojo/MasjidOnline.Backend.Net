using System.Collections.Generic;
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
    }

    public async Task CommitAsync()
    {
    }
}
