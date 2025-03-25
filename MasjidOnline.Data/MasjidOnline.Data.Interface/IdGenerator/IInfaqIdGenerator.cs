using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IInfaqIdGenerator
{
    int InfaqId { get; }
    int InfaqFileId { get; }
    int ExpireId { get; }
    int SuccessId { get; }
    int VoidId { get; }

    Task InitializeAsync(IData infaqDatabase);
}
