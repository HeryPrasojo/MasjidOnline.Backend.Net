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
    Task AddAndSaveAsync(Entity.Infaq.Infaq infaq);
    Task<int> GetMaxIdAsync();
    Task<GetOne?> GetOneAsync(int id);
    Task<GetManyResult<GetManyRecord>> GetManyAsync(IEnumerable<PaymentType>? paymentTypes = null, IEnumerable<PaymentStatus>? paymentStatuses = null, GetManyOrderBy getManyOrderBy = GetManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<ExpiredAdd?> GetForExpiredAddAsync(int id);
    void UpdatePaymentStatus(int id, PaymentStatus paymentStatus);
    Task<GetManyResult<GetManyDueRecord>> GetManyDueAsync(DateTime dueDateTime, IEnumerable<PaymentType>? paymentTypes = null, GetManyOrderBy getManyOrderBy = GetManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<GetOneDue?> GetOneDueAsync(int id);
}
