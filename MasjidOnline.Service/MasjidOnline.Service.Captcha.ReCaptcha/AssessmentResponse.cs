namespace MasjidOnline.Service.Captcha.ReCaptcha;

public class AssessmentResponse
{
    public required RiskAnalysisClass RiskAnalysis { get; set; }

    public class RiskAnalysisClass
    {
        public required float Score { get; set; }
    }
}
