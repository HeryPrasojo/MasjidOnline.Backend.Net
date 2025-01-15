using System;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Core;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Data.IdGenerator;

public class CoreIdGenerator : ICoreIdGenerator
{
    public CoreIdGenerator(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var coreData = serviceScope.ServiceProvider.GetService<ICoreData>()
            ?? throw new ApplicationException($"Get ICoreData service fail");
    }
}
