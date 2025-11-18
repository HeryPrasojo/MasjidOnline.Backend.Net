using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Business.Session.Interface.Model.Sessions;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionCreateBusiness(IService _service) : ISessionCreateBusiness
{
    public async Task<Response<string>> CreateAsync(IData _data, Interface.Model.Session session, CreateRequest createRequest)
    {
        if (session.Id != default) return new()
        {
            ResultCode = ResponseResultCode.Success,
        };

        createRequest = _service.FieldValidator.ValidateRequired(createRequest);

        createRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(createRequest.CaptchaToken);


        var isVerified = await _service.Captcha.VerifyAsync(createRequest.CaptchaToken, "session");

        if (!isVerified) throw new InputMismatchException(nameof(createRequest.CaptchaToken));


        session.CultureInfo = Service.Localization.Interface.Model.Constant.CultureInfoEnglish;
        session.Id = _data.IdGenerator.Session.SessionId;
        session.UserId = Model.Constant.UserId.Anonymous;

        var sessionEntity = new Entity.Session.Session
        {
            ApplicationCulture = Mapper.Mapper.User.UserPreferenceApplicationCulture[session.CultureInfo],
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
