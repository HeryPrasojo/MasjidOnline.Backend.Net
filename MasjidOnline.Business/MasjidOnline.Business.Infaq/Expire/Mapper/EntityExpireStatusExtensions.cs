using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business.Infaq.Expire.Mapper;

// todo move to Mapper project
public static class EntityExpireStatusExtensions
{
    public static ExpireStatus ToModel(this Entity.Infaq.ExpireStatus expireStatus)
    {
        return expireStatus switch
        {
            Entity.Infaq.ExpireStatus.Approve
                => ExpireStatus.Approve,

            Entity.Infaq.ExpireStatus.Cancel
                => ExpireStatus.Cancel,

            Entity.Infaq.ExpireStatus.New
                => ExpireStatus.New,

            Entity.Infaq.ExpireStatus.Reject
                => ExpireStatus.Reject,

            _ => throw new ErrorException(nameof(expireStatus)),
        };
    }
}
