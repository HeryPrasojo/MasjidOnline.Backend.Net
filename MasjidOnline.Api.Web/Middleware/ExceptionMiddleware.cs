using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class ExceptionMiddleware(
    RequestDelegate _nextRequestDelegate,
    IEventIdGenerator _eventIdGenerator)
{
    public async Task Invoke(HttpContext httpContext, IEventDatabase eventDatabase)
    {
        try
        {
            await _nextRequestDelegate(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception, eventDatabase);
        }
    }

    protected virtual ExceptionResponse BuildExceptionResponse(Exception exception)
    {
        var exceptionResponse = new ExceptionResponse
        {
            ResultCode = ResponseResultCode.Error,
        };

        if (exception is InputInvalidException or BadHttpRequestException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.InputInvalid;
        }
        else if (exception is InputMismatchException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.InputMismatch;
        }
        else if (exception is DataMismatchException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.DataMismatch;
        }
        else if (exception is PermissionException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.Success;
        }

        return exceptionResponse;
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception, IEventDatabase eventDatabase)
    {
        var exceptionResponse = BuildExceptionResponse(exception);

        httpContext.Response.ContentType = "application/json";

        var responseString = JsonSerializer.Serialize(exceptionResponse, options: JsonSerializerOptions.Web);

        await httpContext.Response.WriteAsync(responseString);


        if (exceptionResponse.ResultCode == ResponseResultCode.Error)
        {
            var exceptionEntities = new List<Entity.Event.Exception>();

            BuildExceptionEntity(exception, exceptionEntities);

            await eventDatabase.Exception.AddAsync(exceptionEntities);

            await eventDatabase.SaveAsync();
        }
    }

    private Entity.Event.Exception BuildExceptionEntity(Exception exception, List<Entity.Event.Exception> exceptionEntities)
    {
        var exceptionEntity = new Entity.Event.Exception
        {
            DateTime = DateTime.UtcNow,
            Id = _eventIdGenerator.ExceptionId,
            Message = exception.Message,
            StackTrace = exception.StackTrace,
            Type = exception.GetType().Name,
        };

        exceptionEntities.Add(exceptionEntity);

        if (exception.InnerException != default)
        {
            var innerExceptionEntities = BuildExceptionEntity(exception.InnerException, exceptionEntities);

            exceptionEntity.InnerExceptionId = innerExceptionEntities.Id;
        }

        return exceptionEntity;
    }
}
