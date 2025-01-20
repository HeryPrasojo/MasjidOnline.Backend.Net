using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Audit;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Audit;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class AuditData(AuditDataContext _auditDataContext) : IAuditData
{
    private IAuditSettingRepository? _auditSettingRepository;

    private IUserLogRepository? _userLogRepository;
    private IUserEmailAddressLogRepository? _userEmailAddressLogRepository;


    public IAuditSettingRepository AuditSetting => _auditSettingRepository ??= new AuditSettingRepository(_auditDataContext);


    public IUserLogRepository UserLog => _userLogRepository ??= new UserLogRepository(_auditDataContext);

    public IUserEmailAddressLogRepository UserEmailAddressLog => _userEmailAddressLogRepository ??= new UserEmailAddressLogRepository(_auditDataContext);


    public async Task SaveAsync()
    {
        await _auditDataContext.SaveChangesAsync();
    }
}