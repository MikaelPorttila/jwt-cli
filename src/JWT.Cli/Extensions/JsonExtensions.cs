using System.Text.Json;

namespace JWT.Cli.Extensions
{
    public static class JsonExtensions
    {
        public static string PrettyJson(this string value)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var jsonElement = JsonSerializer.Deserialize<JsonElement>(value);
            return JsonSerializer.Serialize(JsonSerializer.Deserialize<JsonElement>(value), options);
        }
    }
}
