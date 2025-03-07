
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Expired.Mapper;

public static class EntityExpiredStatusExtensions
{
    public static Interface.Model.Expired.ExpiredStatus ToModel(this Entity.Infaq.ExpiredStatus expiredStatus)
    {
        return expiredStatus switch
        {
            Entity.Infaq.ExpiredStatus.Approve
                => Interface.Model.Expired.ExpiredStatus.Approve,

            Entity.Infaq.ExpiredStatus.Cancel
                => Interface.Model.Expired.ExpiredStatus.Cancel,

            Entity.Infaq.ExpiredStatus.New
                => Interface.Model.Expired.ExpiredStatus.New,

            Entity.Infaq.ExpiredStatus.Reject
                => Interface.Model.Expired.ExpiredStatus.Reject,

            _ => throw new ErrorException(nameof(expiredStatus)),
        };
    }
}
