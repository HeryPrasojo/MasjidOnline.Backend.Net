using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Audit;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class AuditData(AuditDataContext _auditDataContext) : IAuditData
{
    private IAuditSettingRepository? _auditSettingRepository;


    public IAuditSettingRepository AuditSetting => _auditSettingRepository ??= new AuditSettingRepository(_auditDataContext);


    public async Task SaveAsync()
    {
        await _auditDataContext.SaveChangesAsync();
    }
}