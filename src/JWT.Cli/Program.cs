using JWT.Cli.Extensions;
using Spectre.Console;
using System.Diagnostics;

AnsiConsole.ResetColors();
AnsiConsole
	.Write(new Rule("[blue]JWT[/]")
	.RuleStyle(Style.Parse("blue"))
	.Centered());
AnsiConsole.WriteLine();

var token = args.FirstOrDefault();
if (string.IsNullOrEmpty(token))
{
	token = AnsiConsole.Ask<string>("[blue]JWT Token:[/]");
	AnsiConsole.WriteLine();
}

const string template = "[{0}]{1}[/]";
var printColors = new[] { "red", "purple_2", "blue" };

var watch = Stopwatch.StartNew();

AnsiConsole.Status()
	.Spinner(Spinner.Known.Arc)
	.Start("Parsing...", ctx =>
	{
		try
		{
			var tokenSections = JwtExtensions.Parse(token).ToArray();
			for (int i = 0; i < tokenSections.Length; i++)
			{
				AnsiConsole.MarkupLine(template, printColors[i], Markup.Escape(tokenSections[i]));
			}
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