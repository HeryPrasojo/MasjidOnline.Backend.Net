using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Success.Mapper;

// todo move to Mapper project
public static class ModelSuccessStatusExtensions
{
    public static Entity.Infaq.SuccessStatus? ToEntity(this SuccessStatus? successStatus)
    {
        return successStatus switch
        {
            SuccessStatus.Approve
                => Entity.Infaq.SuccessStatus.Approve,

            SuccessStatus.Cancel
                => Entity.Infaq.SuccessStatus.Cancel,

            SuccessStatus.New
                => Entity.Infaq.SuccessStatus.New,

            SuccessStatus.Reject
                => Entity.Infaq.SuccessStatus.Reject,

            null => default,

            _ => throw new ErrorException(nameof(successStatus)),
        };
    }
}
