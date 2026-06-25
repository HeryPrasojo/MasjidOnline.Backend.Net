using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Donation.Donation;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Entity.Donation;
using MasjidOnline.Entity.Payment;

namespace MasjidOnline.Data.Interface.Repository.Donation;

public interface IDonationRepository
{
    Task AddAsync(Entity.Donation.Donation Donation);
    Task<int> GetMaxIdAsync();
    Task<View?> GetFirstOrDefaultAsync(int id);
    Task<TableResult<TableRecord>> GetTableAsync(IEnumerable<PaymentType>? paymentTypes = null, IEnumerable<DonationStatus>? paymentStatuses = null, int skip = 0, int take = 1);
    Task<ExpireAdd?> GetForExpireAddAsync(int id);
    void SetStatus(int id, DonationStatus paymentStatus);
    Task<SuccessAdd?> GetForSuccessAddAsync(int id);
    Task<VoidAdd?> GetForVoidAddAsync(int id);
}



