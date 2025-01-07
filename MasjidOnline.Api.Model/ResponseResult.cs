namespace MasjidOnline.Api.Model
{
    public enum ResponseResult
    {
        Success = 0,
        AccessFail = 5,
        AccessExpired = 7,
        Error = 9,
        InputInvalid = 11,
        InputMismatch = 21,
        DataMismatch = 22,

        CaptchaPassed = 111,
    }
}