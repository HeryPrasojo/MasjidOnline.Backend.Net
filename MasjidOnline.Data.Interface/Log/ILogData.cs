namespace MasjidOnline.Data.Interface.Log;

public interface ILogData : IData
{
    IErrorExceptionRepository Exception { get; }
    ILogSettingRepository LogSetting { get; }
}
