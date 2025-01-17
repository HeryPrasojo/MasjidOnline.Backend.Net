using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Log;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.Repository.Log;

namespace MasjidOnline.Data.EntityFramework.Datas;

public class LogData(LogDataContext _logDataContext) : ILogData
{
    private ILogSettingRepository? _logSettingRepository;

    private IErrorExceptionRepository? _errorExceptionRepository;


    public ILogSettingRepository LogSetting => _logSettingRepository ??= new LogSettingRepository(_logDataContext);


    public IErrorExceptionRepository Exception => _errorExceptionRepository ??= new ErrorExceptionRepository(_logDataContext);


    public async Task SaveAsync()
    {
        await _logDataContext.SaveChangesAsync();
    }
}
