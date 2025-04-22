using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class DatabaseTemplateIdGenerator : IDatabaseTemplateIdGenerator
{
    // undone rename
    private int _tableTemplateId;

    public async Task InitializeAsync(IData data)
    {
        _tableTemplateId = await data.DatabaseTemplate.Table.GetMaxIdAsync();
    }

    // undone rename
    public int TableTemplateId => Interlocked.Increment(ref _tableTemplateId);
}
