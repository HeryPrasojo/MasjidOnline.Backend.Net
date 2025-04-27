using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class PaymentEndpoint
{
    internal static class Manual
    {
        internal static async Task<Business.Payment.Interface.Model.Manual.GetRecommendationNoteResponse> GetRecommendationNoteAsync(
            IBusiness _business,
            Session session,
            IData _data)
        {
            return await _business.Payment.Manual.GetRecommendationNote.Get(_data, session);
        }
    }
}
