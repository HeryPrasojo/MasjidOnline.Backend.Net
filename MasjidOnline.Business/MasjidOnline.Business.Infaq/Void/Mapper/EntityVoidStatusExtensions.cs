using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Void.Mapper;

public static class EntityVoidStatusExtensions
{
    public static VoidStatus ToModel(this Entity.Infaq.VoidStatus voidStatus)
    {
        return voidStatus switch
        {
            Entity.Infaq.VoidStatus.Approve
                => VoidStatus.Approve,

            Entity.Infaq.VoidStatus.Cancel
                => VoidStatus.Cancel,

            Entity.Infaq.VoidStatus.New
                => VoidStatus.New,

            Entity.Infaq.VoidStatus.Reject
                => VoidStatus.Reject,

            _ => throw new ErrorException(nameof(voidStatus)),
        };
    }
}
