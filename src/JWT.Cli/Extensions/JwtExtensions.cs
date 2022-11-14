using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace JWT.Cli.Extensions
{
	public static class JwtExtensions
	{
		private static readonly JsonSerializerOptions s_jsonSerializerOptions = new()
		{
			WriteIndented = true
		};

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

		public static IEnumerable<string> Parse(string token)
		{
			if (string.IsNullOrEmpty(token))
			{
				return Array.Empty<string>();
			}

			return token
				.Split('.', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
				.Take(2)
				.Select((section) => Base64UrlEncoder.Decode(section).FormatJson());
		}

		private static string FormatJson(this string value)
		{
			return JsonSerializer.Serialize(JsonSerializer.Deserialize<JsonElement>(value), s_jsonSerializerOptions);
		}
	}
}
