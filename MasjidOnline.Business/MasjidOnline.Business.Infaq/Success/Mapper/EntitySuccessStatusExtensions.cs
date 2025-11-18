using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Success.Mapper;

// todo move to Mapper project
public static class EntitySuccessStatusExtensions
{
    public static SuccessStatus ToModel(this Entity.Infaq.SuccessStatus successStatus)
    {
        return successStatus switch
        {
            Entity.Infaq.SuccessStatus.Approve
                => SuccessStatus.Approve,

            Entity.Infaq.SuccessStatus.Cancel
                => SuccessStatus.Cancel,

            Entity.Infaq.SuccessStatus.New
                => SuccessStatus.New,

            Entity.Infaq.SuccessStatus.Reject
                => SuccessStatus.Reject,

            _ => throw new ErrorException(nameof(successStatus)),
        };
    }
}
