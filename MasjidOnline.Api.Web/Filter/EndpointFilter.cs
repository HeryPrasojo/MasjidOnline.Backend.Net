using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extensions;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Filter;

public class EndpointFilter(IBusiness _business) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        try
        {
            return await next.Invoke(context);
        }
        catch (Exception exception)
        {
            if (exception.GetType() == typeof(BadHttpRequestException))
            {
                exception = new InputInvalidException("BadHttpRequestException", exception);
            }


            var exceptionResponse = _business.ExceptionResponse.Build(exception);

            if (exceptionResponse.ResultCode == ResponseResultCode.Error)
            {
                var _data = context.HttpContext.RequestServices.GetServiceOrThrow<IData>();

                await _business.Event.Exception.LogAsync(_data, exception);
            }

            return exceptionResponse;
        }
    }
}
