# `jwt-cli`
_[![Spectre.Console NuGet Version](https://img.shields.io/nuget/v/jwt.cli.svg?style=flat&label=NuGet%3A%20JWT.Cli)](https://www.nuget.org/packages/JWT.Cli)_

Small tool for handling daily tasks with json web tokens.
Lets keep tokens safe by not posting them on the internet.

## Install as dotnet tool from NuGet:
```shell
dotnet tool install --global JWT.Cli
```

## Build and setup globally as dotnet tooling:

1. Clone the repo

2. Build
```shell
dotnet pack ./src -c Release
```

3. Install globally
```shell
dotnet tool install --global --add-source ./src/jwt.cli/nupkg JWT.Cli 
```

To uninstall:
```shell
dotnet tool uninstall jwt.cli --global 
```
