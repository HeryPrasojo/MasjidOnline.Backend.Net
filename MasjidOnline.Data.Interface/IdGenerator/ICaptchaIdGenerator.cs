namespace MasjidOnline.Data.Interface.IdGenerator;

public interface ICaptchaIdGenerator
{
    int CaptchaQuestionId { get; }
    int CaptchaAnswerId { get; }
}
