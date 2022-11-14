using JWT.Cli.Extensions;
using Spectre.Console;
using System.Diagnostics;
using System.Security.Principal;

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
			var tokenSections = JwtExtensions.Parse(token);
			var index = 0;
			foreach (var section in tokenSections)
			{
				AnsiConsole.MarkupLine(template, printColors[index], Markup.Escape(section));
				index++;
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
