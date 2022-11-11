:: @echo off

:: Uninstall old versions | Build | Install globally
dotnet tool uninstall jwt.cli --global && dotnet pack ./src -c Release && dotnet tool install --global --add-source ./src/jwt.cli/nupkg JWT.Cli