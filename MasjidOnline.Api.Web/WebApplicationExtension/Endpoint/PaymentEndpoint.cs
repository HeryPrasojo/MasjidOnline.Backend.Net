using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Payment.Manual;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class PaymentEndpoint
{
    internal static class Manual
    {
        internal static async Task<Response<string>> GetRecommendationNoteAsync(
            IBusiness _business,
            Session session,
            IData _data,
            [FromBody] GetRecommendationNoteRequest getRecommendationNoteRequest)
        {
            return await _business.Payment.Manual.GetRecommendationNote.GetAsync(_data, session, getRecommendationNoteRequest);
        }
    }
}
