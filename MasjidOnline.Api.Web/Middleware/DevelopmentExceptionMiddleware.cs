using System;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class DevelopmentExceptionMiddleware(
    RequestDelegate _nextRequestDelegate,
    IEventIdGenerator _eventIdGenerator) : ExceptionMiddleware(_nextRequestDelegate, _eventIdGenerator)
{
    protected override ExceptionResponse BuildExceptionResponse(Exception exception)
    {
        var exceptionResponse = base.BuildExceptionResponse(exception);

        if (exception is PermissionException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.PermissionMismatch;
        }

        exceptionResponse.Exception = BuildExceptionResponseException(exception);

        return exceptionResponse;
    }

    public ExceptionResponseException BuildExceptionResponseException(Exception exception)
    {
        var exceptionResponseException = new ExceptionResponseException
        {
            Message = exception.Message,
            StackTrace = exception.StackTrace,
        };

        if (exception.InnerException != default)
        {
            exceptionResponseException.InnerException = BuildExceptionResponseException(exception.InnerException);
        }

        return exceptionResponseException;
    }
}
