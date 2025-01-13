using System;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Exception;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Log;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web;

public class ExceptionHandlerMiddleware(RequestDelegate _nextRequestDelegate)
{
    public async Task Invoke(HttpContext httpContext, ILogData logData, ILogIdGenerator logIdGenerator)
    {
        try
        {
            await _nextRequestDelegate(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception, logData, logIdGenerator);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception, ILogData logData, ILogIdGenerator logIdGenerator)
    {
        httpContext.Response.ContentType = "application/json";

        var response = new Response
        {
            ResultCode = ResponseResult.Error,
            ResultMessage = exception.Message,
        };

        if (exception is InputInvalidException) response.ResultCode = ResponseResult.InputInvalid;
        else if (exception is InputMismatchException) response.ResultCode = ResponseResult.InputMismatch;
        else if (exception is DataMismatchException) response.ResultCode = ResponseResult.DataMismatch;


        var responseString = JsonSerializer.Serialize(response, options: JsonSerializerOptions.Web);

        var responseWriteTask = httpContext.Response.WriteAsync(responseString);


        if (response.ResultCode == ResponseResult.Error)
        {
            var errorExceptionEntity = new Entity.Log.ErrorException
            {
                Id = logIdGenerator.ErrorExceptionId,
                Message = exception.Message,
                StackTrace = exception.StackTrace,
                CreateDateTime = DateTime.UtcNow,
            };

            await logData.ErrorException.AddAndSaveAsync(errorExceptionEntity);
        }


        responseWriteTask.Wait();
    }
}
