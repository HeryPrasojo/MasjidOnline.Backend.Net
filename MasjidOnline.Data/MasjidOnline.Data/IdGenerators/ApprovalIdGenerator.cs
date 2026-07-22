using System.Threading;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.IdGenerator;

namespace MasjidOnline.Data.IdGenerators;

public class ApprovalIdGenerator : IApprovalIdGenerator
{
    private int _approvalId;
    private int _approvalStepId;

    public async Task InitializeAsync(IData data)
    {
        _approvalId = await data.Approval.Approval.GetMaxIdAsync();
        _approvalStepId = await data.Approval.ApprovalStep.GetMaxIdAsync();
    }

    public int ApprovalId => Interlocked.Increment(ref _approvalId);
    public int ApprovalStepId => Interlocked.Increment(ref _approvalStepId);
}
