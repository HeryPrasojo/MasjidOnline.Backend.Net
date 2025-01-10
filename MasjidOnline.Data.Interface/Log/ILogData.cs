namespace MasjidOnline.Data.Interface.Log;

public interface ILogData : IData
{
    IErrorExceptionRepository ErrorException { get; }
}
