
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.User.Internal.Mapper;

public static class ModelInternalStatusExtensions
{
    public static Entity.User.InternalStatus? ToEntity(this Interface.Model.Internal.InternalStatus? internalStatus)
    {
        return internalStatus switch
        {
            Interface.Model.Internal.InternalStatus.Approve
                => Entity.User.InternalStatus.Approve,

            Interface.Model.Internal.InternalStatus.Cancel
                => Entity.User.InternalStatus.Cancel,

            Interface.Model.Internal.InternalStatus.New
                => Entity.User.InternalStatus.New,

            Interface.Model.Internal.InternalStatus.Reject
                => Entity.User.InternalStatus.Reject,

            null => default,

            _ => throw new ErrorException(nameof(internalStatus)),
        };
    }
}
