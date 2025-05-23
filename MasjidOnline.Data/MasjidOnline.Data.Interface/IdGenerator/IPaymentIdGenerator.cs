using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IPaymentIdGenerator
{
    int ManualRecommendationIdId { get; }

    Task InitializeAsync(IData data);
}
