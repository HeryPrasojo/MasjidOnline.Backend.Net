using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.SqLite.Initializer;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public class DataInitializer(
    AccountancyDataContext _accountancyDataContext,
    AuditDataContext _auditDataContext,
    AuthorizationDataContext _authorizationDataContext,
    CaptchaDataContext _captchaDataContext,
    EventDataContext _eventDataContext,
    InfaqDataContext _infaqDataContext,
    PaymentDataContext _paymentDataContext,
    PersonDataContext _personDataContext,
    SessionDataContext _sessionDataContext,
    UserDataContext _userDataContext,
    VerificationDataContext _verificationDataContext
    ) : IDataInitializer
{
    private readonly AccountancyInitializer _accountancyInitializer =
        new(_accountancyDataContext, new DataDefinition<AccountancyDataContext>(_accountancyDataContext));

    private readonly AuditInitializer _auditInitializer =
        new(_auditDataContext, new DataDefinition<AuditDataContext>(_auditDataContext));

    private readonly AuthorizationInitializer _authorizationInitializer =
        new(_authorizationDataContext, new DataDefinition<AuthorizationDataContext>(_authorizationDataContext));

    private readonly CaptchaInitializer _captchaInitializer =
        new(_captchaDataContext, new DataDefinition<CaptchaDataContext>(_captchaDataContext));

    private readonly EventInitializer _eventInitializer =
        new(_eventDataContext, new DataDefinition<EventDataContext>(_eventDataContext));

    private readonly InfaqInitializer _infaqInitializer =
        new(_infaqDataContext, new DataDefinition<InfaqDataContext>(_infaqDataContext));

    private readonly PaymentInitializer _paymentInitializer =
        new(_paymentDataContext, new DataDefinition<PaymentDataContext>(_paymentDataContext));

    private readonly PersonInitializer _personInitializer =
        new(_personDataContext, new DataDefinition<PersonDataContext>(_personDataContext));

    private readonly SessionInitializer _sessionInitializer =
        new(_sessionDataContext, new DataDefinition<SessionDataContext>(_sessionDataContext));

    private readonly UserInitializer _userInitializer =
        new(_userDataContext, new DataDefinition<UserDataContext>(_userDataContext));

    private readonly VerificationInitializer _verificationInitializer =
        new(_verificationDataContext, new DataDefinition<VerificationDataContext>(_verificationDataContext));

    public async Task InitializeAsync(IData data)
    {
        await _accountancyInitializer.InitializeDatabaseAsync(data);
        await _auditInitializer.InitializeDatabaseAsync(data);
        await _authorizationInitializer.InitializeDatabaseAsync(data);
        await _captchaInitializer.InitializeDatabaseAsync(data);
        await _eventInitializer.InitializeDatabaseAsync(data);
        await _infaqInitializer.InitializeDatabaseAsync(data);
        await _paymentInitializer.InitializeDatabaseAsync(data);
        await _personInitializer.InitializeDatabaseAsync(data);
        await _sessionInitializer.InitializeDatabaseAsync(data);
        await _userInitializer.InitializeDatabaseAsync(data);
        await _verificationInitializer.InitializeDatabaseAsync(data);
    }
}
