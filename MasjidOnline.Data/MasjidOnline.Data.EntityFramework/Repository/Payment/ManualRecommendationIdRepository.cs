using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Payment;
using MasjidOnline.Entity.Payment;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Payment;

public class ManualRecommendationIdRepository(PaymentDataContext _databaseDataContext) : IManualRecommendationIdRepository
{
    private readonly DbSet<ManualRecommendationId> _dbSet = _databaseDataContext.Set<ManualRecommendationId>();

    public async Task AddAsync(ManualRecommendationId manualRecommendationId)
    {
        await _dbSet.AddAsync(manualRecommendationId);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
