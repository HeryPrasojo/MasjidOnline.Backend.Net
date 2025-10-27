using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace MasjidOnline.Api.Web.HostedServices;

public class SessionExpireHostedService : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
    }
}
