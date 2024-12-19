using MasjidOnline.Api.Web;
using MasjidOnline.Business.Captcha;
using MasjidOnline.Business.Donation;
using MasjidOnline.Data.EntityFramework.SqLite;
using MasjidOnline.Service.Captcha;
using MasjidOnline.Service.Hash512;
using Microsoft.AspNetCore.Builder;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddCaptchaService();

webApplicationBuilder.Services.AddHash512Service();

webApplicationBuilder.Services.AddSqLiteEntityFrameworkDataAccess(webApplicationBuilder.Configuration);

webApplicationBuilder.Services.AddDonationBusiness();

webApplicationBuilder.Services.AddCaptchaBusiness();

var webApplication = webApplicationBuilder.Build();

//webApplication.UseHttpsRedirection();

webApplication.MapEndpoint();

webApplication.Run();
