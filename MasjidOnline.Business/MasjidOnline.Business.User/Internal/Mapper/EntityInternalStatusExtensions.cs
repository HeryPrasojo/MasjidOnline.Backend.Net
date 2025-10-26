
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.User.Internal.Mapper;

public static class EntityInternalStatusExtensions
{
    public static Interface.Model.Internal.InternalUserStatus ToModel(this Entity.User.InternalUserStatus status)
    {
        return status switch
        {
            Entity.User.InternalUserStatus.Approve
                => Interface.Model.Internal.InternalUserStatus.Approve,

            Entity.User.InternalUserStatus.Cancel
                => Interface.Model.Internal.InternalUserStatus.Cancel,

            Entity.User.InternalUserStatus.New
                => Interface.Model.Internal.InternalUserStatus.New,

            Entity.User.InternalUserStatus.Reject
                => Interface.Model.Internal.InternalUserStatus.Reject,

            _ => throw new ErrorException(nameof(status)),
        };
    }
}
