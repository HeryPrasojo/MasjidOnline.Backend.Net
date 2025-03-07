
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Expired.Mapper;

public static class ModelExpiredStatusExtensions
{
    public static Entity.Infaq.ExpiredStatus? ToEntity(this Interface.Model.Expired.ExpiredStatus? expiredStatus)
    {
        return expiredStatus switch
        {
            Interface.Model.Expired.ExpiredStatus.Approve
                => Entity.Infaq.ExpiredStatus.Approve,

            Interface.Model.Expired.ExpiredStatus.Cancel
                => Entity.Infaq.ExpiredStatus.Cancel,

            Interface.Model.Expired.ExpiredStatus.New
                => Entity.Infaq.ExpiredStatus.New,

            Interface.Model.Expired.ExpiredStatus.Reject
                => Entity.Infaq.ExpiredStatus.Reject,

            null => default,

            _ => throw new ErrorException(nameof(expiredStatus)),
        };
    }
}
