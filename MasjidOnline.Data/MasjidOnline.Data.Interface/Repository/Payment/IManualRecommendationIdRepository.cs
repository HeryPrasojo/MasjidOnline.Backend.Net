using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Payment.ManualRecommendationIdRepository;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.Repository.Payment;

public interface IManualRecommendationIdRepository
{
    Task AddAndSaveAsync(ManualRecommendationId manualRecommendationId);
    Task<LastBySessionId?> GetLastBySessionIdAsync(int sessionId);
    Task<int> GetMaxIdAsync();
}
