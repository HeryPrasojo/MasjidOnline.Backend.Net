using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Payment;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetOneBusiness(IService _service) : IGetOneBusiness
{
    public async Task<GetOneResponse> GetAsync(Session.Interface.Model.Session session, IData _data, GetOneRequest? getOneRequest)
    {
        getOneRequest = _service.FieldValidator.ValidateRequired(getOneRequest);
        getOneRequest.Id = _service.FieldValidator.ValidateRequiredPlus(getOneRequest.Id);


        var infaq = await _data.Infaq.Infaq.GetOneAsync(getOneRequest.Id.Value);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");


        var getOneResponseInfaq = new GetOneResponseInfaq()
        {
            Amount = _service.Localization[infaq.Amount, session.CultureInfo],
            DateTime = _service.Localization[infaq.DateTime, session.CultureInfo],
            MunfiqName = infaq.MunfiqName,
            PaymentStatus = _service.Localization[infaq.PaymentStatus, session.CultureInfo],
            PaymentType = _service.Localization[infaq.PaymentType, session.CultureInfo],
        };


        if (!session.IsUserAnonymous)
        {
            var userType = await _data.User.User.GetTypeAsync(session.UserId);

            if (userType == UserType.Internal)
            {

            }

            _data.Authorization.UserInternalPermission.GetByUserIdAsync();// undone check authorization

            var manualPaymentTypes = new PaymentType[] { PaymentType.ManualBankTransfer, PaymentType.ManualCash, PaymentType.ManualGopay };

            if (manualPaymentTypes.Contains(infaq.PaymentType))
            {
                if (infaq.PaymentStatus == PaymentStatus.New)
                {

                }
            }
        }


        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Infaq = getOneResponseInfaq,
        };
    }
}
