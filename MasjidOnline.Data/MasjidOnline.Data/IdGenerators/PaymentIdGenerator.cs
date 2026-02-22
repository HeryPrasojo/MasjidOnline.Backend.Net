using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class PaymentIdGenerator : IPaymentIdGenerator
{
    private int _manualRecommendationIdId;
    private int _paymentId;
    private int _paymentFileId;

    public async Task InitializeAsync(IData data)
    {
        _manualRecommendationIdId = await data.Payment.ManualRecommendationId.GetMaxIdAsync();
        _paymentId = await data.Payment.Payment.GetMaxIdAsync();
        _paymentFileId = await data.Payment.PaymentFile.GetMaxIdAsync();

        if (_manualRecommendationIdId < 100000) _manualRecommendationIdId = 100000;
    }

    public int ManualRecommendationIdId => Interlocked.Increment(ref _manualRecommendationIdId);

    public int PaymentId => Interlocked.Increment(ref _paymentId);

    public int PaymentFileId => Interlocked.Increment(ref _paymentFileId);
}
