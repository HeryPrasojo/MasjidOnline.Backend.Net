using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Interface;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Filter;

public class EndpointFilter(IService _service) : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var result = await next.Invoke(context);

        if (result == default) return default;


        var session = context.HttpContext.RequestServices.GetServiceOrThrow<Session>();

        return _service.Serializer.Serialize(result, session.CultureInfo);
    }
}
