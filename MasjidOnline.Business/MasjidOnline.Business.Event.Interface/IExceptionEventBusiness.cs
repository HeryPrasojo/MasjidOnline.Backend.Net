
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Event.Interface;

public interface IExceptionEventBusiness
{
    Task HandleAsync(IData data, Exception exception);
}
