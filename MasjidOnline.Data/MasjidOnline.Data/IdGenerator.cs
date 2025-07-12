using System.Threading.Tasks;
using MasjidOnline.Data.IdGenerators;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Data;

public class IdGenerator(IService _service) : IIdGenerator
{
    private readonly AccountancyIdGenerator _accountancyIdGenerator = new();
    private readonly AuditIdGenerator _auditIdGenerator = new();
    private readonly AuthorizationIdGenerator _authorizationIdGenerator = new();
    private readonly EventIdGenerator _eventIdGenerator = new();
    private readonly InfaqIdGenerator _infaqIdGenerator = new();
    private readonly PaymentIdGenerator _paymentIdGenerator = new();
    private readonly PersonIdGenerator _personIdGenerator = new();
    private readonly SessionIdGenerator _sessionIdGenerator = new(_service.Hash512);
    private readonly UserIdGenerator _userIdGenerator = new(_service.Hash512);
    //private readonly DatabaseTemplateIdGenerator _databaseTemplateIdGenerator = new();

    public IAccountancyIdGenerator Accountancy => _accountancyIdGenerator;
    public IAuditIdGenerator Audit => _auditIdGenerator;
    public IAuthorizationIdGenerator Authorization => _authorizationIdGenerator;
    public IEventIdGenerator Event => _eventIdGenerator;
    public IInfaqIdGenerator Infaq => _infaqIdGenerator;
    public IPaymentIdGenerator Payment => _paymentIdGenerator;
    public IPersonIdGenerator Person => _personIdGenerator;
    public ISessionIdGenerator Session => _sessionIdGenerator;
    public IUserIdGenerator User => _userIdGenerator;
    //public IDatabaseTemplateIdGenerator DatabaseTemplate => _databaseTemplateIdGenerator;

    public async Task InitializeAsync(IData _data)
    {
        await _accountancyIdGenerator.InitializeAsync(_data);
        await _auditIdGenerator.InitializeAsync(_data);
        await _authorizationIdGenerator.InitializeAsync(_data);
        await _eventIdGenerator.InitializeAsync(_data);
        await _infaqIdGenerator.InitializeAsync(_data);
        await _paymentIdGenerator.InitializeAsync(_data);
        await _personIdGenerator.InitializeAsync(_data);
        await _sessionIdGenerator.InitializeAsync(_data);
        await _userIdGenerator.InitializeAsync(_data);
        //await _databaseTemplateIdGenerator.InitializeAsync(_data);
    }
}