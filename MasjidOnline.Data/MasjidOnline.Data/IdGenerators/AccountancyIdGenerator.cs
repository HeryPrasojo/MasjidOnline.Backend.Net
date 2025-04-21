using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class AccountancyIdGenerator : IAccountancyIdGenerator
{
    private int _expenditureId;

    public async Task InitializeAsync(IData data)
    {
        _expenditureId = await data.Accountancy.Expenditure.GetMaxIdAsync();
    }

    public int ExpenditureId => Interlocked.Increment(ref _expenditureId);
}
