namespace MasjidOnline.Library.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrEmptyOrWhiteSpace(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }
}
