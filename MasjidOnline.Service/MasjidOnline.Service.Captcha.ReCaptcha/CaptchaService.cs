using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Service.Captcha.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Service.Captcha.ReCaptcha;

public class CaptchaService(IOptionsMonitor<GoogleOptions> _optionsMonitor) : ICaptchaService
{
    public async Task VerifyAsync(string token, string action)
    {
        using var httpClient = new HttpClient();

        var request = new
        {
            Event = new
            {
                ExpectedAction = action,
                SiteKey = "6LdSD_oqAAAAAOS497xVyGNjp5AAN-TpvCxk8b5R",
                Token = token,
            },
        };

        var serializeJsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        var serializedRequest = JsonSerializer.Serialize(request, serializeJsonSerializerOptions);

        using var stringContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

        using var httpResponseMessage = await httpClient.PostAsync(_optionsMonitor.CurrentValue.ReCaptchaAssessmentsUri, stringContent);

        var serializedResponse = await httpResponseMessage.Content.ReadAsStringAsync();
    }

    //public async Task VerifyAsync(string token, string action)
    //{
    //    var recaptchaEnterpriseServiceClient = await RecaptchaEnterpriseServiceClient.CreateAsync();

    //    var projectName = new ProjectName("masjidonline-pro-1742437216294");

    //    var createAssessmentRequest = new CreateAssessmentRequest()
    //    {
    //        Assessment = new Assessment()
    //        {
    //            Event = new Event()
    //            {
    //                SiteKey = "6LdSD_oqAAAAAOS497xVyGNjp5AAN-TpvCxk8b5R",
    //                Token = token,
    //                ExpectedAction = action
    //            },
    //        },
    //        ParentAsProjectName = projectName
    //    };

    //    var assessment = await recaptchaEnterpriseServiceClient.CreateAssessmentAsync(createAssessmentRequest);

    //    if (assessment.TokenProperties.Valid == false)
    //    {
    //        System.Console.WriteLine("The CreateAssessment call failed because the token was: " + assessment.TokenProperties.InvalidReason.ToString());
    //    }

    //    if (assessment.TokenProperties.Action != action)
    //    {
    //        System.Console.WriteLine("The action attribute in reCAPTCHA tag is: " + assessment.TokenProperties.Action.ToString());
    //        System.Console.WriteLine("The action attribute in the reCAPTCHA tag does not match the action you are expecting to score");
    //    }

    //    // Get the risk score and the reason(s).
    //    // For more information on interpreting the assessment, see:
    //    // https://cloud.google.com/recaptcha-enterprise/docs/interpret-assessment
    //    System.Console.WriteLine("The reCAPTCHA score is: " + ((decimal)assessment.RiskAnalysis.Score));

    //    foreach (RiskAnalysis.Types.ClassificationReason reason in assessment.RiskAnalysis.Reasons)
    //    {
    //        System.Console.WriteLine(reason.ToString());
    //    }
    //}
}
