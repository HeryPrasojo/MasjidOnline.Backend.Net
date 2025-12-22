using MasjidOnline.Business.Mapper.Event;
using MasjidOnline.Business.Mapper.Infaq;
using MasjidOnline.Business.Mapper.Payment;
using MasjidOnline.Business.Mapper.User;
using MasjidOnline.Business.Mapper.Verification;

namespace MasjidOnline.Business.Mapper;

public static class Mapper
{
    public static class Event
    {
        public static UserLoginClientMapper UserLoginClient => new();
    }

    public static class Infaq
    {
        public static InfaqStatusMapper InfaqStatus => new();
    }

    public static class Payment
    {
        public static PaymentTypeMapper PaymentType => new();
    }

    public static class Session
    {
        public static readonly Business.Mapper.Session.UserPreferenceApplicationCultureMapper UserPreferenceApplicationCulture = new();
    }

    public static class User
    {
        public static readonly InternalUserStatusMapper InternalUserStatus = new();

        public static readonly UserPreferenceApplicationCultureMapper UserPreferenceApplicationCulture = new();

        public static readonly UserTypeMapper UserType = new();
    }

    public static class Verification
    {
        public static readonly ContactTypeMapper ContactType = new();
    }
}
