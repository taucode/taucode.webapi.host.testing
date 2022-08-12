dotnet restore

dotnet clean --configuration Debug
dotnet clean --configuration Release

dotnet build --configuration Debug
dotnet build --configuration Release

dotnet test -c Debug .\test\TauCode.WebApi.Testing.Tests\TauCode.WebApi.Testing.Tests.csproj
dotnet test -c Release .\test\TauCode.WebApi.Testing.Tests\TauCode.WebApi.Testing.Tests.csproj

nuget pack nuget\TauCode.WebApi.Testing.nuspec
