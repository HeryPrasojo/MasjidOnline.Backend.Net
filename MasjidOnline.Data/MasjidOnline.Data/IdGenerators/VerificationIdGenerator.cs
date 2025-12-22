using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class VerificationIdGenerator : IVerificationIdGenerator
{
    private int _verificationCodeId;

    public async Task InitializeAsync(IData data)
    {
        _verificationCodeId = await data.Verification.VerificationCode.GetMaxIdAsync();
    }

    public int VerificationCodeId => Interlocked.Increment(ref _verificationCodeId);
}
