using System.Runtime.CompilerServices;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Service.FieldValidator;

public class FieldValidatorService : IFieldValidatorService
{
    public string? ValidateOptionalTextShort(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) return default;


        value = value.Trim();

        var length = value.Length;

        if (length == 0) return default;

        if (length > 255) throw new InputInvalidException(valueExpression);

        return value;
    }

    public void ValidateRequired(decimal? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (!value.HasValue) throw new InputInvalidException(valueExpression);

        if (value < 1m) throw new InputInvalidException(valueExpression);
    }

    public void ValidateRequired(Enum? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value is null) throw new InputInvalidException(valueExpression);

        var valueType = value.GetType();

        if (!Enum.IsDefined(valueType, value)) throw new InputInvalidException(valueExpression);
    }

    public void ValidateRequired<TObject>(TObject? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default) where TObject : class
    {
        if (value == default) throw new InputInvalidException(valueExpression);
    }

    public string ValidateRequiredTextShort(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        var length = value.Length;

        if (length == 0 || length > 255) throw new InputInvalidException(valueExpression);

        return value;
    }
}
