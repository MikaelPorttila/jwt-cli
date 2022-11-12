using Spectre.Console;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using JWT.Cli.Extensions;

AnsiConsole.ResetColors();
AnsiConsole
	.Write(new Rule("[blue]JWT[/]")
	.RuleStyle(Style.Parse("blue"))
	.Centered());
AnsiConsole.WriteLine();

var token = args.FirstOrDefault();
if (token == null)
{
	token = AnsiConsole.Ask<string>("[blue]JWT Token:[/]");
	AnsiConsole.WriteLine();
}

var watch = Stopwatch.StartNew();
AnsiConsole.Status()
	.Spinner(Spinner.Known.Arc)
	.Start("Parsing...", ctx =>
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		try
		{
			var parsedToken = tokenHandler.ReadJwtToken(token.Trim());
			AnsiConsole.MarkupLine($"[red]{parsedToken.Header.Print()}[/]");
			AnsiConsole.MarkupLine($"[purple_2]{parsedToken.Payload.Print()}[/]");
		}
		catch (ArgumentException)
		{
			AnsiConsole.MarkupLine($"[darkorange3_1]Invalid token[/]");
		}
		catch (Exception)
		{
			AnsiConsole.MarkupLine($"[red]Something went wrong during parsing[/]");
		}
	});

watch.Stop();
AnsiConsole.WriteLine();
AnsiConsole
	.Write(new Rule($"[blue]{watch.ElapsedMilliseconds} ms[/]")
	.RuleStyle(Style.Parse("blue"))
	.Centered());

Console.ReadKey();