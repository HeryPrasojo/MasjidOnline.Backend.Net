using System;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class DevelopmentExceptionMiddleware(
    RequestDelegate _nextRequestDelegate,
    IIdGenerator _idGenerator) : ExceptionMiddleware(_nextRequestDelegate, _idGenerator)
{
    protected override Response<ExceptionResponse> BuildExceptionResponse(Exception exception)
    {
        var exceptionResponse = base.BuildExceptionResponse(exception);

        if (exception is PermissionException)
        {
            exceptionResponse.ResultMessage = exception.Message;
        }

        exceptionResponse.Data = BuildExceptionResponseException(exception);

        return exceptionResponse;
    }

    private static ExceptionResponse BuildExceptionResponseException(Exception exception)
    {
        var exceptionResponseException = new ExceptionResponse
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
