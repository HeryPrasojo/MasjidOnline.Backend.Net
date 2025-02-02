using System.Runtime.CompilerServices;

namespace MasjidOnline.Service.FieldValidator.Interface;

public interface IFieldValidatorService
{
    string? ValidateOptionalTextShort(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default);
    void ValidateRequired<TObject>(TObject? value, [CallerArgumentExpression("value")] string? valueExpression = default) where TObject : class;
    void ValidateRequiredPlus(decimal? value, [CallerArgumentExpression("value")] string? valueExpression = default);
    void ValidateRequired(Enum? value, string? valueExpression = null);
    void ValidateRequiredPast(DateTime? value, [CallerArgumentExpression("value")] string? valueExpression = null);
    string ValidateRequiredEmailAddress(string? value, [CallerArgumentExpression("value")] string? valueExpression = null);
    string ValidateRequiredTextShort(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default);
    byte[] ValidateRequiredHex(string? value, int valueLength = 0, [CallerArgumentExpression("value")] string? valueExpression = null);
    void ValidateRequired(string? value, int valueMaximumLength, [CallerArgumentExpression("value")] string? valueExpression = null);
    byte[] ValidateRequiredBase64(string? value, int valueLength, [CallerArgumentExpression("value")] string? valueExpression = null);
}
