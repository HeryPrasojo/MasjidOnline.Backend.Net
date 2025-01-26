using System.Runtime.CompilerServices;

namespace MasjidOnline.Service.FieldValidator.Interface;

public interface IFieldValidatorService
{
    string? ValidateOptionalTextShort(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default);
    void ValidateRequired<TObject>(TObject? value, [CallerArgumentExpression("value")] string? valueExpression = default) where TObject : class;
    void ValidateRequired(decimal? value, [CallerArgumentExpression("value")] string? valueExpression = default);
    void ValidateRequired(Enum? value, string? valueExpression = null);
    void ValidateRequiredDateTimePast(DateTime? value, [CallerArgumentExpression("value")] string? valueExpression = null);
    string ValidateRequiredTextShort(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default);
}
