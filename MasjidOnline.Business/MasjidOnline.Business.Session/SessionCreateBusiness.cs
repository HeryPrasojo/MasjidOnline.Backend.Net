using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session.Sessions;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Session;

public class SessionCreateBusiness(IService _service) : ISessionCreateBusiness
{
    public async Task<Response<string>> CreateAsync(IData _data, Model.Session.Session session, CreateRequest createRequest)
    {
        if (session.Id != default) return new()
        {
            ResultCode = ResponseResultCode.Success,
        };

        createRequest = _service.FieldValidator.ValidateRequired(createRequest);

        createRequest.CaptchaToken = _service.FieldValidator.ValidateRequired(createRequest.CaptchaToken);
        createRequest.ApplicationCulture = _service.FieldValidator.ValidateRequiredEnum(createRequest.ApplicationCulture);


        var isVerified = await _service.Captcha.VerifySessionAsync(createRequest.CaptchaToken);

        if (!isVerified) throw new InputMismatchException(nameof(createRequest.CaptchaToken));


        var userPreferenceApplicationCultureEntity = Mapper.Mapper.User.UserPreferenceApplicationCulture[createRequest.ApplicationCulture.Value];

        session.CultureInfo = Mapper.Mapper.Session.UserPreferenceApplicationCulture[userPreferenceApplicationCultureEntity];
        session.Id = _data.IdGenerator.Session.SessionId;
        session.UserId = Model.Constant.UserId.Anonymous;

        var sessionEntity = new Entity.Session.Session
        {
            ApplicationCulture = userPreferenceApplicationCultureEntity,
            DateTime = DateTime.UtcNow,
            Code = _service.Hash512.RandomByteArray,
            Id = session.Id,
            UserId = session.UserId,
        };

        await _data.Session.Session.AddAndSaveAsync(sessionEntity);

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = _service.Encryption256kService.EncryptBase64(sessionEntity.Code.AsSpan()),
        };
    }
}
