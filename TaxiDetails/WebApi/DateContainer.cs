using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaxiDetails.WebApi;

/// <summary>
/// JSON converter for handling values in the "yyyy-MM-dd" format.
/// </summary>
public class DateConverter : JsonConverter<DateOnly>
{
    /// <summary>
    /// template of format.
    /// </summary>
    private const string Format = "yyyy-MM-dd";

    /// <summary>
    /// read format.
    /// </summary>
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateOnly.ParseExact(reader.GetString()!, Format);
    }
    /// <summary>
    /// write format.
    /// </summary>
    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format));
    }
}

