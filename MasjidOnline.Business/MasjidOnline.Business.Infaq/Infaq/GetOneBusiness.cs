using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Infaq;
using MasjidOnline.Business.Model.Infaq.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Entity.Payment;
using MasjidOnline.Entity.User;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class GetOneBusiness(IService _service) : IGetOneBusiness
{
    public async Task<Response<GetOneResponse>> GetAsync(Model.Session.Session session, IData _data, GetOneRequest? getOneRequest)
    {
        getOneRequest = _service.FieldValidator.ValidateRequired(getOneRequest);
        getOneRequest.Id = _service.FieldValidator.ValidateRequiredPlus(getOneRequest.Id);


        var infaq = await _data.Infaq.Infaq.GetOneAsync(getOneRequest.Id.Value);

        if (infaq == default) throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");


        var getOneResponseInfaq = new GetOneResponseInfaq()
        {
            Amount = _service.Localization[infaq.Amount, session.CultureInfo],
            DateTime = _service.Localization[infaq.DateTime, session.CultureInfo, "yyyy MMM dd, HH:mm"],
            MunfiqName = infaq.MunfiqName,
            PaymentStatus = _service.Localization[infaq.Status, session.CultureInfo],
            PaymentType = _service.Localization[infaq.PaymentType, session.CultureInfo],
        };


        // todo wait move to each entity

        var getOneResponseFlags = new GetOneResponseFlags();

        if (!session.IsUserAnonymous)
        {
            PaymentType[] manualPaymentTypes = [
                PaymentType.ManualBankTransfer,
                PaymentType.ManualCash,
                PaymentType.ManualGopay,
            ];

            if (manualPaymentTypes.Contains(infaq.PaymentType))
            {
                InfaqStatus[] infaqStatuses = [
                    InfaqStatus.CancelRequest,
                    InfaqStatus.ExpireRequest,
                    InfaqStatus.FailRequest,
                    InfaqStatus.New,
                    InfaqStatus.SuccessRequest,
                    InfaqStatus.Success,
                    InfaqStatus.VoidRequest,
                ];

                if (infaqStatuses.Any(s => s == infaq.Status))
                {
                    var userType = await _data.User.User.GetTypeAsync(session.UserId);

                    if (userType == UserType.Internal)
                    {
                        var userInternalPermission = await _data.Authorization.UserInternalPermission.FirstOrDefaultAsync(session.UserId)
                            ?? throw new DataMismatchException("UserInternalPermission " + session.UserId);

                        if (infaq.Status == InfaqStatus.New)
                        {
                            if (userInternalPermission.InfaqExpireAdd)
                            {
                                if (infaq.DateTime < System.DateTime.UtcNow.AddDays(-3d)) getOneResponseFlags.CanAddExpire = true;
                            }

                            if (userInternalPermission.InfaqSuccessAdd) getOneResponseFlags.CanAddSuccess = true;
                        }
                        else if (infaq.Status == InfaqStatus.ExpireRequest)
                        {
                            if (userInternalPermission.InfaqExpireApprove) getOneResponseFlags.CanApproveExpire = true;
                        }
                        else if (infaq.Status == InfaqStatus.SuccessRequest)
                        {
                            if (userInternalPermission.InfaqSuccessApprove) getOneResponseFlags.CanApproveSuccess = true;
                        }
                        else if (infaq.Status == InfaqStatus.Success)
                        {
                            // todo wait check infaq finalized
                            if (userInternalPermission.InfaqVoidAdd) getOneResponseFlags.CanAddVoid = true;
                        }
                        else if (infaq.Status == InfaqStatus.VoidRequest)
                        {
                            if (userInternalPermission.InfaqVoidApprove) getOneResponseFlags.CanAddVoid = true;
                        }
                    }
                }
            }
        }


        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new GetOneResponse()
            {
                Amount = _service.Localization[infaq.Amount, session.CultureInfo],
                DateTime = _service.Localization[infaq.DateTime, session.CultureInfo, "yyyy MMM dd, HH:mm"],
                MunfiqName = infaq.MunfiqName,
                Status = _service.Localization[infaq.Status, session.CultureInfo],
                PaymentType = _service.Localization[infaq.PaymentType, session.CultureInfo],
                Flags = getOneResponseFlags,
                Infaq = getOneResponseInfaq,
            },
        };
    }
}
