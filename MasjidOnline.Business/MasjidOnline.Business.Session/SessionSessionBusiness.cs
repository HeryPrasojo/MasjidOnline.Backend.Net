using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.Session.Interface.Model.Sessions;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionSessionBusiness(IService _service, IIdGenerator _idGenerator) : ISessionSessionBusiness
{
    public async Task<Response<string>> CreateAsync(IData _data, Interface.Model.Session session, string? cultureName, CreateRequest createRequest)
    {
        if (session.Id != default) return new()
        {
            ResultCode = ResponseResultCode.Success,
        };

        createRequest = _service.FieldValidator.ValidateRequired(createRequest);

        createRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(createRequest.CaptchaToken);


        var isVerified = await _service.Captcha.VerifyAsync(createRequest.CaptchaToken, "session");

        if (!isVerified) throw new InputMismatchException(nameof(createRequest.CaptchaToken));


        session.Id = _idGenerator.Session.SessionId;
        session.UserId = Model.Constant.UserId.Anonymous;

        if (cultureName.IsNullOrEmptyOrWhiteSpace())
        {
            session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfoEnglish;
        }
        else
        {
            session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfos[cultureName!];
        }

        var sessionEntity = new Entity.Session.Session
        {
            ApplicationCulture = Model.Constant.UserPreferenceApplicationCulture[session.CultureInfo],
            DateTime = DateTime.UtcNow,
            Code = _service.Hash512.RandomByteArray,
            Id = session.Id,
            UserId = session.UserId,
        };

        await _data.Session.Session.AddAndSaveAsync(sessionEntity);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = Convert.ToBase64String(_service.Encryption128b256kService.Encrypt(sessionEntity.Code.AsSpan())),
        };
    }
}
