using System;
using System.Threading.Tasks;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Session;

public class SessionExpireBusiness : ISessionExpireBusiness
{
    public async Task ExpireAsync(IData _data)
    {
        await _data.Session.Session.RemoveExpireAsync(DateTime.UtcNow);
    }
}
