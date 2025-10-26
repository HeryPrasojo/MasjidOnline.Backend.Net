
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.User.Internal.Mapper;

public static class ModelInternalStatusExtensions
{
    public static Entity.User.InternalUserStatus? ToEntity(this Interface.Model.Internal.InternalUserStatus? status)
    {
        return status switch
        {
            Interface.Model.Internal.InternalUserStatus.Approve
                => Entity.User.InternalUserStatus.Approve,

            Interface.Model.Internal.InternalUserStatus.Cancel
                => Entity.User.InternalUserStatus.Cancel,

            Interface.Model.Internal.InternalUserStatus.New
                => Entity.User.InternalUserStatus.New,

            Interface.Model.Internal.InternalUserStatus.Reject
                => Entity.User.InternalUserStatus.Reject,

            null => default,

            _ => throw new ErrorException(nameof(status)),
        };
    }
}
