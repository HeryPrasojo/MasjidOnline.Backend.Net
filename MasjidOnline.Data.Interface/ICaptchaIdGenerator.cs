namespace MasjidOnline.Data.Interface;

public interface ICaptchaIdGenerator
{
    long CaptchaQuestionId { get; }
    long CaptchaAnswerId { get; }
}
