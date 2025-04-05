namespace MasjidOnline.Business.Model.Responses;

public enum ResponseResultCode
{
    Success = 0,
    SessionMismatch = 3,
    SessionExpire = 5,
    PermissionMismatch = 7,
    Error = 9,
    InputInvalid = 11,
    InputMismatch = 21,
    DataMismatch = 22,

    CaptchaPass = 111,
    CaptchaWrong = 112,
    CaptchaNeed = 113,
    CaptchaUnneed = 114,
    CaptchaUnpass = 115,
}