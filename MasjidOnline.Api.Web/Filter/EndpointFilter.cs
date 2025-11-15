using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Library.Extensions;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Filter;

public class EndpointFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var session = context.HttpContext.RequestServices.GetServiceOrThrow<Session>();
        Console.WriteLine($"EndpointFilter: {GetHashCode()}, {session.Id}");
        var result = await next.Invoke(context);

        return result;
    }
}
