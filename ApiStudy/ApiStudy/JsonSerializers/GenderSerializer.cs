using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiStudy.JsonSerializers
{
    public class GenderSerializer : JsonConverter<string>
    {
        public override string? Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return reader.GetString();
        }

        public override void Write(
            Utf8JsonWriter writer,
            string value,
            JsonSerializerOptions options)
        {
            var formatted = value == "Male" ? "M" : "F";
            writer.WriteStringValue(formatted);
        }
    }
}
