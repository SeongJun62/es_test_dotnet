using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class SapDatsConverter : JsonConverter<DateTime?>
{
    private static readonly string[] Formats =
    {
        "yyyyMMdd",     // SAP 원형
        "yyyy-MM-dd"    // ISO
    };

    public override DateTime? Read(ref Utf8JsonReader reader,
        Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var str = reader.GetString();
            if (DateTime.TryParseExact(
                    str,
                    Formats,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out var dt))
            {
                return dt;
            }
        }

        return null;
    }

    public override void Write(Utf8JsonWriter writer,
        DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString("yyyyMMdd"));
        else
            writer.WriteNullValue();
    }
}