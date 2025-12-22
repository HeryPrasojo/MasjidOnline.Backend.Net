using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IVerificationIdGenerator
{
    int VerificationCodeId { get; }

    Task InitializeAsync(IData data);
}
