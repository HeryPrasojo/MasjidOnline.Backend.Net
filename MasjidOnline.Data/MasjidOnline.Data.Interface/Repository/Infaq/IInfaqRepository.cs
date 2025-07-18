using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Infaq.Infaq;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IInfaqRepository
{
    Task AddAsync(Entity.Infaq.Infaq infaq);
    Task<int> GetMaxIdAsync();
    Task<One?> GetOneAsync(int id);
    Task<ManyResult<ManyRecord>> GetManyAsync(IEnumerable<PaymentType>? paymentTypes = null, IEnumerable<InfaqStatus>? paymentStatuses = null, int skip = 0, int take = 1);
    Task<ExpireAdd?> GetForExpireAddAsync(int id);
    void SetStatus(int id, InfaqStatus paymentStatus);
    Task<SuccessAdd?> GetForSuccessAddAsync(int id);
    Task<VoidAdd?> GetForVoidAddAsync(int id);
}
