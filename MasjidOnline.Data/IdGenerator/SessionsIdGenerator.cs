using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Datas;
using MasjidOnline.Data.Interface.IdGenerator;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Data.IdGenerator;

public class SessionsIdGenerator(IHash512Service _hash512Service) : ISessionsIdGenerator
{

    public async Task InitializeAsync(ISessionsData sessionData)
    {
        await Task.CompletedTask;
    }

    public byte[] SessionId => _hash512Service.RandomDigestBytes;
}
