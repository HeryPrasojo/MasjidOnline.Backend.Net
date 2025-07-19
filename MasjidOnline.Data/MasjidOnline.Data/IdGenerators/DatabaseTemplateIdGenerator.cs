using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class DatabaseTemplateIdGenerator : IDatabaseTemplateIdGenerator
{
    // undone template rename
    private int _tableTemplateId;

    public async Task InitializeAsync(IData data)
    {
        _tableTemplateId = await data.DatabaseTemplate.TableTemplate.GetMaxIdAsync();
    }

    // undone template rename
    public int TableTemplateId => Interlocked.Increment(ref _tableTemplateId);
}
