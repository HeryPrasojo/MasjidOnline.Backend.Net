
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.User.Internal.Mapper;

public static class EntityInternalStatusExtensions
{
    public static Interface.Model.Internal.InternalStatus ToModel(this Entity.User.InternalStatus internalStatus)
    {
        return internalStatus switch
        {
            Entity.User.InternalStatus.Approve
                => Interface.Model.Internal.InternalStatus.Approve,

            Entity.User.InternalStatus.Cancel
                => Interface.Model.Internal.InternalStatus.Cancel,

            Entity.User.InternalStatus.New
                => Interface.Model.Internal.InternalStatus.New,

            Entity.User.InternalStatus.Reject
                => Interface.Model.Internal.InternalStatus.Reject,

            _ => throw new ErrorException(nameof(internalStatus)),
        };
    }
}
