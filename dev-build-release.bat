dotnet restore

dotnet build --configuration Debug
dotnet build --configuration Release

dotnet test -c Debug .\tests\TauCode.WebApi.Testing.Tests\TauCode.WebApi.Testing.Tests.csproj
dotnet test -c Release .\tests\TauCode.WebApi.Testing.Tests\TauCode.WebApi.Testing.Tests.csproj

nuget pack nuget\TauCode.WebApi.Testing.nuspec
