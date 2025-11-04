using MasjidOnline.Business.Event.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Event;

public class ExceptionEventBusiness() : IExceptionEventBusiness
{
    public async Task HandleAsync(IData _data, Exception exception)
    {
        var exceptionEntities = new List<Entity.Event.Exception>();

        BuildExceptionEntity(_data, exception, exceptionEntities, DateTime.UtcNow);

        await _data.Transaction.RollbackAsync();

        await _data.Event.Exception.AddAndSaveAsync(exceptionEntities);
    }

    private static Entity.Event.Exception BuildExceptionEntity(IData _data, Exception exception, List<Entity.Event.Exception> exceptionEntities, DateTime dateTime)
    {
        var exceptionEntity = new Entity.Event.Exception
        {
            DateTime = dateTime,
            Id = _data.IdGenerator.Event.ExceptionId,
            Message = exception.Message,
            StackTrace = exception.StackTrace,
            Type = exception.GetType().Name,
        };

        exceptionEntities.Add(exceptionEntity);

        if (exception.InnerException != default)
        {
            var innerExceptionEntities = BuildExceptionEntity(_data, exception.InnerException, exceptionEntities, dateTime);

            exceptionEntity.InnerExceptionId = innerExceptionEntities.Id;
        }

        return exceptionEntity;
    }
}
