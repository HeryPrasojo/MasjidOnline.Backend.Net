using System;
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
    Task<InfaqForGetOne?> GetOneAsync(int id);
    Task<GetManyResult<InfaqForGetManyRecord>> GetManyAsync(IEnumerable<PaymentType>? paymentTypes = null, IEnumerable<PaymentStatus>? paymentStatuses = null, GetManyOrderBy getManyOrderBy = GetManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<InfaqForExpiredAdd?> GetForExpiredAddAsync(int id);
    void UpdatePaymentStatus(int id, PaymentStatus paymentStatus);
    Task<GetManyResult<InfaqForGetManyDueRecord>> GetManyDueAsync(DateTime dueDateTime, IEnumerable<PaymentType>? paymentTypes = null, GetManyOrderBy getManyOrderBy = GetManyOrderBy.None, OrderByDirection orderByDirection = OrderByDirection.Default, int skip = 0, int take = 1);
    Task<InfaqForGetOneDue?> GetOneDueAsync(int id);
}
