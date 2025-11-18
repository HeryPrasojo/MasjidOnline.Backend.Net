using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Void.Mapper;

// todo move to Mapper project
public static class ModelVoidStatusExtensions
{
    public static Entity.Infaq.VoidStatus? ToEntity(this VoidStatus? voidStatus)
    {
        return voidStatus switch
        {
            VoidStatus.Approve
                => Entity.Infaq.VoidStatus.Approve,

            VoidStatus.Cancel
                => Entity.Infaq.VoidStatus.Cancel,

            VoidStatus.New
                => Entity.Infaq.VoidStatus.New,

            VoidStatus.Reject
                => Entity.Infaq.VoidStatus.Reject,

            null => default,

            _ => throw new ErrorException(nameof(voidStatus)),
        };
    }
}
