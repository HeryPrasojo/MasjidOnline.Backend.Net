using System.Threading.Tasks;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.Repository.Payment;

public interface IManualRecommendationIdRepository
{
    Task AddAsync(ManualRecommendationId manualRecommendationId);
    Task<int> GetMaxIdAsync();
}
