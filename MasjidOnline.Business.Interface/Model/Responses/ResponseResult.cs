namespace MasjidOnline.Business.Interface.Model.Responses;

public enum ResponseResult
{
    Success = 0,
    SessionMismatch = 3,
    SessionExpired = 5,
    PermissionMismatch = 7,
    Error = 9,
    InputInvalid = 11,
    InputMismatch = 21,
    DataMismatch = 22,

    CaptchaPassed = 111,
    CaptchaWrong = 112,
    CaptchaNeeded = 113,
    CaptchaNotPassed = 114,
}