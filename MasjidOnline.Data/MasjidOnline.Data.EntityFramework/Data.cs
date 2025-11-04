using System;
using MasjidOnline.Data.EntityFramework.Databases;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Library.Extensions;

namespace MasjidOnline.Data.EntityFramework;

public class Data(IServiceProvider _serviceProvider) : MasjidOnline.Data.Data()
{
    private IAccountancyDatabase? _accountancyDatabase;
    private IAuditDatabase? _auditDatabase;
    private IAuthorizationDatabase? _authorizationDatabase;
    private ICaptchaDatabase? _captchaDatabase;
    private IDatabaseTemplateDatabase? _databaseTemplateDatabase;
    private IEventDatabase? _eventDatabase;
    private IIdGenerator? _idGenerator;
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
                var dataContext = _serviceProvider.GetServiceOrThrow<AccountancyDataContext>();

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
                var dataContext = _serviceProvider.GetServiceOrThrow<AuditDataContext>();

                _auditDatabase = new AuditDatabase(dataContext);
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
                var dataContext = _serviceProvider.GetServiceOrThrow<AuthorizationDataContext>();

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
                var dataContext = _serviceProvider.GetServiceOrThrow<CaptchaDataContext>();

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
                var dataContext = _serviceProvider.GetServiceOrThrow<DatabaseTemplateDataContext>();

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
                var dataContext = _serviceProvider.GetServiceOrThrow<EventDataContext>();

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
                var dataContext = _serviceProvider.GetServiceOrThrow<InfaqDataContext>();

                _infaqDatabase = new InfaqDatabase(dataContext);
            }

            return _infaqDatabase;
        }
    }

    public override IIdGenerator IdGenerator
    {
        get
        {
            if (_idGenerator == default)
            {
                _idGenerator = _serviceProvider.GetServiceOrThrow<IIdGenerator>();
            }

            return _idGenerator;
        }
    }

    public override IPaymentDatabase Payment
    {
        get
        {
            if (_paymentDatabase == default)
            {
                var dataContext = _serviceProvider.GetServiceOrThrow<PaymentDataContext>();

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
                var dataContext = _serviceProvider.GetServiceOrThrow<PersonDataContext>();

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
                var dataContext = _serviceProvider.GetServiceOrThrow<SessionDataContext>();

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
                var dataContext = _serviceProvider.GetServiceOrThrow<UserDataContext>();

                _userDatabase = new UserDatabase(dataContext);
            }

            return _userDatabase;
        }
    }
}
