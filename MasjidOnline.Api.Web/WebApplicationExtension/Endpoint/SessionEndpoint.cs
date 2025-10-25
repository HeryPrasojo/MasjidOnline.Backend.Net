using System.Threading.Tasks;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface.Model.Sessions;
using MasjidOnline.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MasjidOnline.Api.Web.WebApplicationExtension.Endpoint;

internal static class SessionEndpoint
{
    internal static class Session
    {
        internal static async Task<Response<string>> CreateAsync(
            IBusiness _business,
            IData _data,
            Business.Session.Interface.Model.Session session,
            string? cultureName,
            [FromBody] CreateRequest createRequest)
        {
            return await _business.Session.Session.CreateAsync(_data, session, cultureName, createRequest);
        }
    }
}
