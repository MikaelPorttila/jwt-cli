using System.IdentityModel.Tokens.Jwt;

namespace JWT.Cli.Extensions
{
	public static class JwtExtensions
	{
		public static string Print(this JwtHeader header)
		{
			if (header == null)
			{
				return string.Empty;
			}

			return header
				.SerializeToJson()
				.PrettyJson();
		}

		public static string Print(this JwtPayload payload)
		{
			if (payload == null)
			{
				return string.Empty;
			}

			return payload
				.SerializeToJson()
				.PrettyJson();
		}
	}
}
