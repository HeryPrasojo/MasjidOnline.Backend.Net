using MasjidOnline.Business.Event.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Event;

public class EventBusiness(IIdGenerator _idGenerator) : IEventBusiness
{
    public IExceptionEventBusiness Exception { get; } = new ExceptionEventBusiness(_idGenerator);

}
