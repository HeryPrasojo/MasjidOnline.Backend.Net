using System;
using MasjidOnline.Business.Interface.Model.Responses;
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
            exceptionResponse.ResultCode = ResponseResult.PermissionMismatch;
        }

        exceptionResponse.ResultMessage = $"{exception.GetType().Name}: {exception.Message}";
        exceptionResponse.StackTrace = exception.StackTrace;
        exceptionResponse.InnerMessage = exception.InnerException?.Message;
        exceptionResponse.InnerStackTrace = exception.InnerException?.StackTrace;

        return exceptionResponse;
    }
}
