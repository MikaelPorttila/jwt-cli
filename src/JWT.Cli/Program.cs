using Spectre.Console;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using JWT.Cli.Extensions;

/////////////////////////////////////////////////////////////////
// Setup and Welcome
/////////////////////////////////////////////////////////////////
AnsiConsole.ResetColors();
AnsiConsole
        .Write(new Rule("[blue]JWT[/]")
        .RuleStyle(Style.Parse("blue"))
        .Centered());
AnsiConsole.WriteLine();

/////////////////////////////////////////////////////////////////
// Business
/////////////////////////////////////////////////////////////////
var firstArgument = args?[0];
if (firstArgument != null)
{
    AnsiConsole.Status()
    .Spinner(Spinner.Known.Arc)
    .Start("Parsing...", ctx => {
        var watch = Stopwatch.StartNew();
        var tokenHandler = new JwtSecurityTokenHandler();
        var parsedToken = tokenHandler.ReadJwtToken(firstArgument);
        AnsiConsole.MarkupLine($"[red]{parsedToken.Header.Print()}[/]");
        AnsiConsole.MarkupLine($"[purple_2]{parsedToken.Payload.Print()}[/]");
        watch.Stop();
        AnsiConsole.WriteLine();
        AnsiConsole
            .Write(new Rule($"[blue]{watch.ElapsedMilliseconds} ms[/]")
            .RuleStyle(Style.Parse("blue"))
            .Centered());
    });
}

Console.ReadKey();