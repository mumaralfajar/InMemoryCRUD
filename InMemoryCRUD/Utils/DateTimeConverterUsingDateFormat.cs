using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InMemoryCRUD.Utils;

public class DateTimeConverterUsingDateFormat : JsonConverter<DateTime>
{
    private const string DateFormat = "dd-MMM-yyyy";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (DateTime.TryParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
        {
            return date;
        }

        throw new JsonException($"Unable to parse '{value}' as date in format {DateFormat}.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(DateFormat));
    }
}