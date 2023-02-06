dotnet restore

dotnet build TauCode.WebApi.Testing.sln -c Debug
dotnet build TauCode.WebApi.Testing.sln -c Release

dotnet test TauCode.WebApi.Testing.sln -c Debug
dotnet test TauCode.WebApi.Testing.sln -c Release

nuget pack nuget\TauCode.WebApi.Testing.nuspec