using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.Infaq.Infaq;
using MasjidOnline.Data.Interface.Model.Repository;
using MasjidOnline.Entity.Infaq;

namespace MasjidOnline.Data.Interface.Repository.Infaq;

public interface IInfaqRepository
{
    Task AddAsync(Entity.Infaq.Infaq infaq);
    Task<int> GetMaxIdAsync();
    Task<One?> GetOneAsync(int id);
    Task<ManyResult<ManyRecord>> GetManyAsync(IEnumerable<PaymentType>? paymentTypes = null, IEnumerable<PaymentStatus>? paymentStatuses = null, ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<ExpiredAdd?> GetForExpiredAddAsync(int id);
    void UpdatePaymentStatus(int id, PaymentStatus paymentStatus);
    Task<ManyResult<ManyDueRecord>> GetManyDueAsync(DateTime dueDateTime, IEnumerable<PaymentType>? paymentTypes = null, ManyOrderBy getManyOrderBy = ManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<OneDue?> GetOneDueAsync(int id);
}
