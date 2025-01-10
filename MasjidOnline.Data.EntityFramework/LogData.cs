using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.Log;
using MasjidOnline.Data.Interface.Log;

namespace MasjidOnline.Data.EntityFramework;

public abstract class LogData : ILogData
{
    protected readonly LogDataContext _logDataContext;

    private IErrorExceptionRepository? _errorExceptionRepository;
    private ILogSettingRepository? _logSettingRepository;

    public LogData(LogDataContext logDataContext)
    {
        _logDataContext = logDataContext;
    }

    public async Task<int> SaveAsync()
    {
        return await _logDataContext.SaveChangesAsync();
    }


    public IErrorExceptionRepository ErrorException => _errorExceptionRepository ??= new ErrorExceptionRepository(_logDataContext);

    public ILogSettingRepository LogSetting => _logSettingRepository ??= new LogSettingRepository(_logDataContext);
}
