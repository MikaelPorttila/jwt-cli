:: @echo off

:: Build | Install globally
dotnet pack ./src -c Release && dotnet tool install --global --add-source ./src/jwt.cli/nupkg JWT.Cli