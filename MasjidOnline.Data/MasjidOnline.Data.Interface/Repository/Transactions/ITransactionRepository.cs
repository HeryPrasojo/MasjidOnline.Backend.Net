using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Data.Interface.Model.Transaction;
using MasjidOnline.Entity.Infaqs;
using MasjidOnline.Entity.Payments;

namespace MasjidOnline.Data.Interface.Repository.Transactions;

public interface ITransactionRepository
{
    Task AddAsync(Infaq transaction);
    Task AddAndSaveAsync(Infaq transaction);
    Task<int> GetMaxIdAsync();
    Task<IEnumerable<Infaq>> QueryAsync(IEnumerable<PaymentStatus>? paymentStatuses = null, TabularQueryOrderBy tabularQueryOrderBy = TabularQueryOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
}
