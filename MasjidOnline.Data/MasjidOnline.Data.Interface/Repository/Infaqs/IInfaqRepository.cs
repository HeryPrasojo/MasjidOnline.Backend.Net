using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Infaq;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Interface.Repository.Infaqs;

public interface IInfaqRepository
{
    Task AddAsync(Infaq transaction);
    Task AddAndSaveAsync(Infaq transaction);
    Task<int> GetMaxIdAsync();
    Task<IEnumerable<InfaqForQuery>> QueryAsync(IEnumerable<PaymentType>? paymentTypes = default, IEnumerable<PaymentStatus>? paymentStatuses = null, TabularQueryOrderBy tabularQueryOrderBy = TabularQueryOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
}
