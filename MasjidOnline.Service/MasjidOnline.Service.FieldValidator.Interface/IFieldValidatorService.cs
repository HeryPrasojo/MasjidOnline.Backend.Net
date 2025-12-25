using System;
using System.Runtime.CompilerServices;

namespace MasjidOnline.Service.FieldValidator.Interface;

public interface IFieldValidatorService
{
    string? ValidateOptionalTextDb255(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default);
    TObject ValidateRequired<TObject>(TObject? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default) where TObject : class;
    decimal ValidateRequiredPlus(decimal? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default);
    DateTime ValidateRequiredPast(DateTime? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    string ValidateRequiredEmailAddress(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    string ValidateRequiredTextDb255(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default);
    byte[] ValidateRequiredHex(string? value, int valueLength = 0, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    byte[] ValidateRequiredBase64(string? value, int valueLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    int ValidateRequiredPlus(int? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    string ValidateRequiredPassword(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    string ValidateRequiredPhoneNumber(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    string ValidateRequired(string? value, int valueMinimumLength, int valueMaximumLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    string ValidateRequired(string? value, int valueLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    TEnum ValidateRequiredEnum<TEnum>(TEnum? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null) where TEnum : struct, Enum;
    string ValidateRequired(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    void ValidateOptionalPast(DateTime? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    void ValidateOptionalEnum<TEnum>(TEnum? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null) where TEnum : struct, Enum;
    DateTime ValidateRequiredFuture(DateTime? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    void ValidateOptionalFuture(DateTime? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    void ValidateRequired<TObject>(TObject value, Func<TObject, bool> predicate, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    byte[] ValidateRequiredBase64Url(string? value, int valueLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
    void ValidateOptionalEnums<TEnum>(System.Collections.Generic.IEnumerable<TEnum>? values, [CallerArgumentExpression(nameof(values))] string? valueExpression = null) where TEnum : struct, Enum;
    bool ValidateRequiredTrue(bool? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = null);
}
