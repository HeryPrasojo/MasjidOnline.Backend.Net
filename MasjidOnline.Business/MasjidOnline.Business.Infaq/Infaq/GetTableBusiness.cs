using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Model.Infaq.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetTableBusiness(IService _service) : IGetTableBusiness
{
    public async Task<Response<TableResponse<TableResponseRecord>>> GetAsync(
        Model.Session.Session session,
        IData _data,
        TableRequest? getTableRequest)
    {
        getTableRequest = _service.FieldValidator.ValidateRequired(getTableRequest);
        getTableRequest.Page = _service.FieldValidator.ValidateRequiredPlus(getTableRequest.Page);
        _service.FieldValidator.ValidateOptionalEnums(getTableRequest.PaymentTypes);
        _service.FieldValidator.ValidateOptionalEnums(getTableRequest.Statuses);


        var paymentTypes = getTableRequest.PaymentTypes?.Select(pt => Mapper.Mapper.Payment.PaymentType[pt]);
        var infaqStatuses = getTableRequest.Statuses?.Select(m => Mapper.Mapper.Infaq.InfaqStatus[m]);

        var take = 10;

        var getTableResult = await _data.Infaq.Infaq.GetTableAsync(
            paymentTypes: paymentTypes,
            paymentStatuses: infaqStatuses,
            skip: (getTableRequest.Page.Value - 1) * take,
            take: take);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                PageCount = ((getTableResult.RecordCount - 1) / take) + 1,
                RecordCount = _service.Localization[getTableResult.RecordCount, session.CultureInfo],
                Records = getTableResult.Records.Select(e => new TableResponseRecord
                {
                    Amount = _service.Localization[e.Amount, session.CultureInfo],
                    DateTime = _service.Localization[e.DateTime, session.CultureInfo, "yyyy MMM dd, HH:mm"],
                    Id = e.Id,
                    MunfiqName = e.MunfiqName,
                    Status = _service.Localization[Mapper.Mapper.Infaq.InfaqStatus[e.Status], session.CultureInfo],
                    PaymentType = _service.Localization[Mapper.Mapper.Payment.PaymentType[e.PaymentType], session.CultureInfo],
                }),
            }
        };
    }
}
