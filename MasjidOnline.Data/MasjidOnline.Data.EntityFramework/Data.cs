using System;
using MasjidOnline.Data.EntityFramework.Databases;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Library.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.EntityFramework;

public class Data(IServiceProvider _serviceProvider) : MasjidOnline.Data.Data()
{
    private IAccountancyDatabase? _accountancyDatabase;
    private IAuditDatabase? _auditDatabase;
    private IAuthorizationDatabase? _authorizationDatabase;
    private ICaptchaDatabase? _captchaDatabase;
    private IDatabaseTemplateDatabase? _databaseTemplateDatabase;
    private IEventDatabase? _eventDatabase;
    private IInfaqDatabase? _infaqDatabase;
    private IPaymentDatabase? _paymentDatabase;
    private IPersonDatabase? _personDatabase;
    private ISessionDatabase? _sessionDatabase;
    private IUserDatabase? _userDatabase;

    public override IAccountancyDatabase Accountancy
    {
        get
        {
            if (_accountancyDatabase == default)
            {
                var dataContext = _serviceProvider.GetService<AccountancyDataContext>() ?? throw new ErrorException($"GetService fail: {nameof(AccountancyDataContext)}");

                _accountancyDatabase = new AccountancyDatabase(dataContext);
            }

            return _accountancyDatabase;
        }
    }

    public override IAuditDatabase Audit
    {
        get
        {
            if (_auditDatabase == default)
            {
                var dataContext = _serviceProvider.GetService<AuditDataContext>() ?? throw new ErrorException($"GetService fail: {nameof(AuditDataContext)}");
                var idGenerator = _serviceProvider.GetService<IIdGenerator>() ?? throw new ErrorException($"GetService fail: {nameof(IIdGenerator)}");

                _auditDatabase = new AuditDatabase(dataContext, idGenerator.Audit);
            }

            return _auditDatabase;
        }
    }

    public override IAuthorizationDatabase Authorization
    {
        get
        {
            if (_authorizationDatabase == default)
            {
                var dataContext = _serviceProvider.GetService<AuthorizationDataContext>() ?? throw new ErrorException($"GetService fail: {nameof(AuthorizationDataContext)}");

                _authorizationDatabase = new AuthorizationDatabase(dataContext);
            }

            return _authorizationDatabase;
        }
    }

    public override ICaptchaDatabase Captcha
    {
        get
        {
            if (_captchaDatabase == default)
            {
                var dataContext = _serviceProvider.GetService<CaptchaDataContext>() ?? throw new ErrorException($"GetService fail: {nameof(CaptchaDataContext)}");

                _captchaDatabase = new CaptchaDatabase(dataContext);
            }

            return _captchaDatabase;
        }
    }

    public override IDatabaseTemplateDatabase DatabaseTemplate
    {
        get
        {
            if (_databaseTemplateDatabase == default)
            {
                var dataContext = _serviceProvider.GetService<DatabaseTemplateDataContext>() ?? throw new ErrorException($"GetService fail: {nameof(DatabaseTemplateDataContext)}");

                _databaseTemplateDatabase = new DatabaseTemplateDatabase(dataContext);
            }

            return _databaseTemplateDatabase;
        }
    }

    public override IEventDatabase Event
    {
        get
        {
            if (_eventDatabase == default)
            {
                var dataContext = _serviceProvider.GetService<EventDataContext>() ?? throw new ErrorException($"GetService fail: {nameof(EventDataContext)}");

                _eventDatabase = new EventDatabase(dataContext);
            }

            return _eventDatabase;
        }
    }

    public override IInfaqDatabase Infaq
    {
        get
        {
            if (_infaqDatabase == default)
            {
                var dataContext = _serviceProvider.GetService<InfaqDataContext>() ?? throw new ErrorException($"GetService fail: {nameof(InfaqDataContext)}");

                _infaqDatabase = new InfaqDatabase(dataContext);
            }

            return _infaqDatabase;
        }
    }

    public override IPaymentDatabase Payment
    {
        get
        {
            if (_paymentDatabase == default)
            {
                var dataContext = _serviceProvider.GetService<PaymentDataContext>() ?? throw new ErrorException($"GetService fail: {nameof(PaymentDataContext)}");

                _paymentDatabase = new PaymentDatabase(dataContext);
            }

            return _paymentDatabase;
        }
    }

    public override IPersonDatabase Person
    {
        get
        {
            if (_personDatabase == default)
            {
                var dataContext = _serviceProvider.GetService<PersonDataContext>() ?? throw new ErrorException($"GetService fail: {nameof(PersonDataContext)}");

                _personDatabase = new PersonDatabase(dataContext);
            }

            return _personDatabase;
        }
    }

    public override ISessionDatabase Session
    {
        get
        {
            if (_sessionDatabase == default)
            {
                var dataContext = _serviceProvider.GetService<SessionDataContext>() ?? throw new ErrorException($"GetService fail: {nameof(SessionDataContext)}");

                _sessionDatabase = new SessionDatabase(dataContext);
            }

            return _sessionDatabase;
        }
    }

    public override IUserDatabase User
    {
        get
        {
            if (_userDatabase == default)
            {
                var dataContext = _serviceProvider.GetService<UserDataContext>() ?? throw new ErrorException($"GetService fail: {nameof(UserDataContext)}");

                _userDatabase = new UserDatabase(dataContext);
            }

            return _userDatabase;
        }
    }
}
