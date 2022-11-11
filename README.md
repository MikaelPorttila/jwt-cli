# jwt-cli
Small tool for handling daily tasks with json web tokens.
Lets keep tokens safe by not posting them on the internet.

Build and setup globally as dotnet tooling:

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