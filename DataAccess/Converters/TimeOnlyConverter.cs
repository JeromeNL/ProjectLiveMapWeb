using Newtonsoft.Json;

namespace DataAccess.Converters;

public class TimeOnlyConverter : JsonConverter<TimeOnly>
{
    public override TimeOnly ReadJson(JsonReader reader, Type objectType, TimeOnly existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        return TimeOnly.Parse((string)reader.Value);
    }

    public override void WriteJson(JsonWriter writer, TimeOnly value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString());
    }
}