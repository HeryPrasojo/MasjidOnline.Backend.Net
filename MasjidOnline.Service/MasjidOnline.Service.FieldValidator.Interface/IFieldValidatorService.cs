using System;
using System.Runtime.CompilerServices;

namespace MasjidOnline.Service.FieldValidator.Interface;

public interface IFieldValidatorService
{
    string? ValidateOptionalText255(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default);
    TObject ValidateRequired<TObject>(TObject? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default) where TObject : class;
    decimal ValidateRequiredPlus(decimal? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default);
    DateTime ValidateRequiredPast(DateTime? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    string ValidateRequiredEmailAddress(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    string ValidateRequiredText255(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default);
    byte[] ValidateRequiredHex(string? value, int valueLength = 0, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    string ValidateRequired(string? value, int valueMaximumLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    byte[] ValidateRequiredBase64(string? value, int valueLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    int ValidateRequiredPlus(int? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    Enum ValidateRequired(Enum? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    string ValidateRequiredPassword(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    string ValidateRequiredPhoneNumber(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
}
