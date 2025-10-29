using System;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class DevelopmentExceptionMiddleware(
    IBusiness _business,
    RequestDelegate _nextRequestDelegate) : ExceptionMiddleware(_business, _nextRequestDelegate)
{
    protected override ExceptionResponse BuildExceptionResponse(Exception exception)
    {
        var exceptionResponse = base.BuildExceptionResponse(exception);

        if (exception is PermissionException)
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
