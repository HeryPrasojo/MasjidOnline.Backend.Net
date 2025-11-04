using MasjidOnline.Business.Event.Interface;

namespace MasjidOnline.Business.Event;

public class EventBusiness() : IEventBusiness
{
    public IExceptionEventBusiness Exception { get; } = new ExceptionEventBusiness();

}
