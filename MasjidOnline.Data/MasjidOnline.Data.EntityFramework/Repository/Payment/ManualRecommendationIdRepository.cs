using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Payment;
using MasjidOnline.Data.Interface.ViewModel.Payment.ManualRecommendationIdRepository;
using MasjidOnline.Entity.Payment;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Payment;

public class ManualRecommendationIdRepository(PaymentDataContext _databaseDataContext) : IManualRecommendationIdRepository
{
    private readonly DbSet<ManualRecommendationId> _dbSet = _databaseDataContext.Set<ManualRecommendationId>();

    public async Task AddAndSaveAsync(ManualRecommendationId manualRecommendationId)
    {
        await _dbSet.AddAsync(manualRecommendationId);

        await _databaseDataContext.SaveChangesAsync();
    }

    public async Task<LastBySessionId?> GetLastBySessionIdAsync(int sessionId)
    {
        return await _dbSet.Where(e => e.SessionId == sessionId)
            .OrderByDescending(e => e.Id)
            .Select(e => new LastBySessionId
            {
                Id = e.Id,
                Used = e.Used,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
