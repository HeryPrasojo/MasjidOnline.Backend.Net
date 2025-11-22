using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Web.Filter;

public class EndpointFilter() : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        return await next.Invoke(context);
    }
}
