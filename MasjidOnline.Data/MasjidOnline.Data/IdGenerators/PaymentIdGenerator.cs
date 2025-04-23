using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class PaymentIdGenerator : IPaymentIdGenerator
{
    private int _tableId;

    public async Task InitializeAsync(IData data)
    {
        _tableId = await data.Payment.ManualRecommendationId.GetMaxIdAsync();
    }

    public int TableId => Interlocked.Increment(ref _tableId);
}
