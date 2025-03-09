using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Expire.Mapper;

public static class ModelExpireStatusExtensions
{
    public static Entity.Infaq.ExpireStatus? ToEntity(this ExpireStatus? expireStatus)
    {
        return expireStatus switch
        {
            ExpireStatus.Approve
                => Entity.Infaq.ExpireStatus.Approve,

            ExpireStatus.Cancel
                => Entity.Infaq.ExpireStatus.Cancel,

            ExpireStatus.New
                => Entity.Infaq.ExpireStatus.New,

            ExpireStatus.Reject
                => Entity.Infaq.ExpireStatus.Reject,

            null => default,

            _ => throw new ErrorException(nameof(expireStatus)),
        };
    }
}
