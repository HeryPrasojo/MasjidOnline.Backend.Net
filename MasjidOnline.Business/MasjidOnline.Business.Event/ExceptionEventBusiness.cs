using MasjidOnline.Business.Event.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Event;

public class ExceptionEventBusiness(IIdGenerator _idGenerator) : IExceptionEventBusiness
{
    public async Task HandleAsync(IData data, Exception exception)
    {
        var exceptionEntities = new List<Entity.Event.Exception>();

        BuildExceptionEntity(exception, exceptionEntities, DateTime.UtcNow);

        await data.Transaction.RollbackAsync();

        await data.Event.Exception.AddAndSaveAsync(exceptionEntities);
    }

    private Entity.Event.Exception BuildExceptionEntity(Exception exception, List<Entity.Event.Exception> exceptionEntities, DateTime dateTime)
    {
        var exceptionEntity = new Entity.Event.Exception
        {
            DateTime = dateTime,
            Id = _idGenerator.Event.ExceptionId,
            Message = exception.Message,
            StackTrace = exception.StackTrace,
            Type = exception.GetType().Name,
        };

        exceptionEntities.Add(exceptionEntity);

        if (exception.InnerException != default)
        {
            var innerExceptionEntities = BuildExceptionEntity(exception.InnerException, exceptionEntities, dateTime);

            exceptionEntity.InnerExceptionId = innerExceptionEntities.Id;
        }

        return exceptionEntity;
    }
}
