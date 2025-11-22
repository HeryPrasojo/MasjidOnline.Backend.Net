using System;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;

namespace MasjidOnline.Business;

public class DevelopmentExceptionResponseBusiness : ExceptionResponseBusiness, IExceptionResponseBusiness
{
    public override ExceptionResponse Build(Exception exception)
    {
        var exceptionResponse = base.Build(exception);

        if (exceptionResponse.ResultMessage == default)
        {
            exceptionResponse.ResultMessage = exception.Message;
        }

        exceptionResponse.Exception = BuildExceptionResponseException(exception);

        return exceptionResponse;
    }

    private static ExceptionResponseException BuildExceptionResponseException(Exception exception)
    {
        var exceptionResponseException = new ExceptionResponseException
        {
            Message = exception.Message,
            StackTrace = exception.StackTrace,
            Type = exception.GetType().Name,
        };

        if (exception.InnerException != default)
        {
            exceptionResponseException.InnerException = BuildExceptionResponseException(exception.InnerException);
        }

        return exceptionResponseException;
    }
}
