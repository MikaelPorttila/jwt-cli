using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace JWT.Cli.Extensions
{
	public static class JwtExtensions
	{
		public static string Print(this IDictionary<string, object> fields)
		{
			if (fields == null)
			{
				return string.Empty;
			}

			return JsonExtensions
				.SerializeToJson(fields)
				.FormatJson();
		}

		private static string FormatJson(this string value)
		{
			return JsonSerializer.Serialize(JsonSerializer.Deserialize<JsonElement>(value), new JsonSerializerOptions()
			{
				WriteIndented = true
			});
		}
	}
}
