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


        var donation = await _data.Donation.Donation.GetFirstOrDefaultAsync(viewRequest.Id.Value);

        if (donation == default) throw new InputMismatchException($"{nameof(viewRequest.Id)}: {viewRequest.Id}");


        var response = new Response<ViewResponse>()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new ViewResponse()
            {
                Amount = _service.Localization[donation.Amount, session.CultureInfo],
                DateTime = _service.Localization[donation.DateTime, session.CultureInfo, "yyyy MMM dd, HH:mm"],
                MunfiqName = donation.MunfiqName,
                Status = Mapper.Mapper.Donation.DonationStatus[donation.Status],
                StatusText = _service.Localization[donation.Status, session.CultureInfo],
                PaymentType = Mapper.Mapper.Payment.PaymentType[donation.PaymentType],
                PaymentTypeText = _service.Localization[donation.PaymentType, session.CultureInfo],
            },
        };

        if (donation.Status == Entity.Donation.DonationStatus.FailRequest)
        {
            var approval = await _data.Approval.Approval.GetViewAsync(Entity.Approval.ApprovalType.Donation, viewRequest.Id.Value)
                ?? throw new DataMismatchException($"donation id: {viewRequest.Id}");

            var person = await _data.Person.Person.GetForDonationViewAsync(approval.UserId)
                ?? throw new DataMismatchException($"user id: {approval.UserId}");


            var mainEmailId = await _data.User.UserData.GetMainEmailIdAsync(approval.UserId);

            var emailAddress = await _data.User.UserEmail.GetAddressAsync(mainEmailId!.Value);


            response.Data.RequestBy = person.Name + " (" + emailAddress + ")";
            response.Data.RequestDateTime = _service.Localization[approval?.DateTime, session.CultureInfo, "yyyy MMM dd, HH:mm"];
        }

        return response;
    }
}



