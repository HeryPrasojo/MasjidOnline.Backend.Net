using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Event.Interface;

public interface IExceptionEventBusiness
{
    Task LogAsync(IData _data, Exception exception);
}
