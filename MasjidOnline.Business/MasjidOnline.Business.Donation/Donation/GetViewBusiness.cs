using System.Threading.Tasks;
using MasjidOnline.Business.Donation.Interface.Donation;
using MasjidOnline.Business.Model.Donation.Donation;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Donation.Donation;

public class GetViewBusiness(IService _service) : IGetViewBusiness
{
    public async Task<Response<ViewResponse>> GetAsync(Model.Session.Session session, IData _data, ViewRequest? viewRequest)
    {
        viewRequest = _service.FieldValidator.ValidateRequired(viewRequest);
        viewRequest.Id = _service.FieldValidator.ValidateRequiredPlus(viewRequest.Id);


        var Donation = await _data.Donation.Donation.GetFirstOrDefaultAsync(viewRequest.Id.Value);

        if (Donation == default) throw new InputMismatchException($"{nameof(viewRequest.Id)}: {viewRequest.Id}");


        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new ViewResponse()
            {
                Amount = _service.Localization[Donation.Amount, session.CultureInfo],
                DateTime = _service.Localization[Donation.DateTime, session.CultureInfo, "yyyy MMM dd, HH:mm"],
                MunfiqName = Donation.MunfiqName,
                Status = _service.Localization[Donation.Status, session.CultureInfo],
                PaymentType = _service.Localization[Donation.PaymentType, session.CultureInfo],
            },
        };
    }
}



