using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.IdGenerator;

public interface IApprovalIdGenerator
{
    int ApprovalId { get; }
    int ApprovalStepId { get; }

    Task InitializeAsync(IData data);
}
