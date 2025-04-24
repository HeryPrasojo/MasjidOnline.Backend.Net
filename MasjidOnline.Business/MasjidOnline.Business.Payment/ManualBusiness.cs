using MasjidOnline.Business.Payment.Interface;
using MasjidOnline.Business.Payment.Interface.Manual;
using MasjidOnline.Business.Payment.Manual;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Payment;

// undone
public class ManualBusiness(IIdGenerator _idGenerator
    ) : IManualBusiness
{
    private IGetRecommendationNoteBusiness _getRecommendationNoteBusiness;

    public IGetRecommendationNoteBusiness GetRecommendationNote => _getRecommendationNoteBusiness ??= new GetRecommendationNoteBusiness();
}
