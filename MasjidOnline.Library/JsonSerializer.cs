using System;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace MasjidOnline.Library;

public static class JsonSerializer
{
    public static string Serialize(object obj, CultureInfo cultureInfo)
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.Append('{');

        var type = obj.GetType();

        var propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var propertySeparatorFlag = false;

        foreach (var propertyInfo in propertyInfos)
        {
            var propertyValue = propertyInfo.GetValue(obj);

            if (propertyValue is Enum)
            {
                var defaultValue = Activator.CreateInstance(propertyInfo.PropertyType);
                var isEqualDefaultValue = propertyValue.Equals(defaultValue);
                if (!isEqualDefaultValue)
                {
                    AppendPropertySeparator(stringBuilder, ref propertySeparatorFlag);

                    AppendPropertyNameAndPairSeparator(stringBuilder, propertyInfo);

                    stringBuilder.Append($"\"{propertyValue}\"");
                }
            }
            else if (propertyValue != default)
            {
                AppendPropertySeparator(stringBuilder, ref propertySeparatorFlag);

                AppendPropertyNameAndPairSeparator(stringBuilder, propertyInfo);

                if (propertyInfo.PropertyType == typeof(string))
                {
                    stringBuilder.Append($"\"{propertyValue}\"");
                }
                else if (propertyInfo.PropertyType.IsPrimitive)
                {
                    stringBuilder.Append(propertyValue);
                }
                else
                {
                    stringBuilder.Append(Serialize(propertyValue, cultureInfo));
                }
            }
        }

        stringBuilder.Append('}');

        return stringBuilder.ToString();
    }

    private static void AppendPropertyNameAndPairSeparator(StringBuilder stringBuilder, PropertyInfo propertyInfo)
    {
        stringBuilder.Append('"');
        stringBuilder.Append(char.ToLower(propertyInfo.Name[0]));
        stringBuilder.Append(propertyInfo.Name[1..]);
        stringBuilder.Append("\":");
    }

    private static void AppendPropertySeparator(StringBuilder stringBuilder, ref bool propertySeparatorFlag)
    {
        if (propertySeparatorFlag)
            stringBuilder.Append(',');
        else
            propertySeparatorFlag = true;
    }
}
