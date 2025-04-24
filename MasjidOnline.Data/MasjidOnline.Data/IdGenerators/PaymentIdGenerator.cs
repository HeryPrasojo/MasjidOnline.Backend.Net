using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class PaymentIdGenerator : IPaymentIdGenerator
{
    private int _manualRecommendationIdId;

    public async Task InitializeAsync(IData data)
    {
        _manualRecommendationIdId = await data.Payment.ManualRecommendationId.GetMaxIdAsync();

        if (_manualRecommendationIdId < 100001) _manualRecommendationIdId = 100001;
    }

    public int ManualRecommendationIdId => Interlocked.Increment(ref _manualRecommendationIdId);
}
