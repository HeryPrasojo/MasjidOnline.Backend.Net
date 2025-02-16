using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Data.Interface.Model.Transaction;
using MasjidOnline.Entity.Payments;
using MasjidOnline.Entity.Transactions;

namespace MasjidOnline.Data.Interface.Repository.Transactions;

public interface ITransactionRepository
{
    Task AddAsync(Transaction transaction);
    Task AddAndSaveAsync(Transaction transaction);
    Task<int> GetMaxIdAsync();
    Task<IEnumerable<Transaction>> QueryAsync(IEnumerable<PaymentStatus>? paymentStatuses = null, TabularQueryOrderBy tabularQueryOrderBy = TabularQueryOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
}
