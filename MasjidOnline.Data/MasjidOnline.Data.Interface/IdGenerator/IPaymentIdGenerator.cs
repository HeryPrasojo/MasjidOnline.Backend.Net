using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IPaymentIdGenerator
{
    int ManualRecommendationIdId { get; }
    int PaymentId { get; }
    int PaymentFileId { get; }

    Task InitializeAsync(IData data);
}
