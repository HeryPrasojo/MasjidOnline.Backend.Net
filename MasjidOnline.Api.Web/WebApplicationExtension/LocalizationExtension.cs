using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Api.Web.WebApplicationExtension;

public static class LocalizationExtension
{
    private static readonly string[] requestCultureProvider = ["en"];

    internal static WebApplication UseLocalization(this WebApplication webApplication)
    {
        webApplication.UseRequestLocalization(requestLocalizationOptions =>
        {
            requestLocalizationOptions.ApplyCurrentCultureToResponseHeaders = true;

            requestLocalizationOptions.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async httpContext =>
            {
                var cultureQueryExists = httpContext.Request.Query.TryGetValue("culture", out var culture);

                if (cultureQueryExists && !string.IsNullOrWhiteSpace(culture))
                {
                    string cultureString = culture.ToString();

                    requestCultureProvider;

                    var session = httpContext.RequestServices.GetService<Session>() ?? throw new ErrorException($"get {nameof(Session)} failed");
                    var data = httpContext.RequestServices.GetService<IData>() ?? throw new ErrorException($"get {nameof(IData)} failed");

                    if (!session.IsUserAnonymous)
                    {
                        var any = await data.User.UserPreference.AnyAsync(session.UserId);

                        if (any)
                        {
                            data.User.UserPreference.SetApplicationCulture();
                        }
                    }

                    // todo save to db

                    return new ProviderCultureResult(cultureString, cultureString);
                }


                // todo check cookie


                // todo check db: session, user


                // todo check http header


                // todo else return default

                return new ProviderCultureResult("", "");
            }));
        });

        return webApplication;
    }
}
