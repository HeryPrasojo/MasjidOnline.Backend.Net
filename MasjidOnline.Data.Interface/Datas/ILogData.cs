using MasjidOnline.Data.Interface.Repository.Log;

namespace MasjidOnline.Data.Interface.Datas;

public interface ILogData : IData
{
    IErrorExceptionRepository Exception { get; }
    ILogSettingRepository LogSetting { get; }
}
