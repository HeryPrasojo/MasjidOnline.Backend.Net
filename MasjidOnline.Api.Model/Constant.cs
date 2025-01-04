namespace MasjidOnline.Api.Model;

public static class Constant
{
    public static class HttpHeaderName
    {
        public static readonly string ResultCode = "Mo-Result-Code";
        public static readonly string ResultMessage = "Mo-Result-Message";
    }

    public static class HttpCookieSessionName
    {
        public static readonly string AnonymousId = "anonSessId";
        public static readonly string UserId = "userSessId";
    }

}
