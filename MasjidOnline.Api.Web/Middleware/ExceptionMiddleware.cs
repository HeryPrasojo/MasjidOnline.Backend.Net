using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Middleware;

public class ExceptionMiddleware(
    RequestDelegate _nextRequestDelegate,
    IIdGenerator _idGenerator)
{
    public async Task Invoke(HttpContext httpContext, IData data)
    {
        try
        {
            await _nextRequestDelegate(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception, data);
        }
    }

    protected virtual Response<ExceptionResponse> BuildExceptionResponse(Exception exception)
    {
        var exceptionResponse = new Response<ExceptionResponse>
        {
            ResultCode = ResponseResultCode.Error,
            ResultMessage = exception.Message,
        };

        if (exception is InputInvalidException or BadHttpRequestException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.InputInvalid;
        }
        else if (exception is InputMismatchException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.InputMismatch;
        }
        else if (exception is SessionExpireException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.SessionExpire;
        }
        else if (exception is PermissionException)
        {
            exceptionResponse.ResultCode = ResponseResultCode.Success;
            exceptionResponse.ResultMessage = default;
        }

        return exceptionResponse;
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception, IData data)
    {
        var exceptionResponse = BuildExceptionResponse(exception);

        httpContext.Response.ContentType = "application/json";

        var responseString = JsonSerializer.Serialize(exceptionResponse, options: JsonSerializerOptions.Web);

        await httpContext.Response.WriteAsync(responseString);


        if (exceptionResponse.ResultCode == ResponseResultCode.Error)
        {
            var exceptionEntities = new List<Entity.Event.Exception>();

            BuildExceptionEntity(exception, exceptionEntities, DateTime.UtcNow);

            await data.Transaction.RollbackAsync();

            await data.Event.Exception.AddAndSaveAsync(exceptionEntities);
        }
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
