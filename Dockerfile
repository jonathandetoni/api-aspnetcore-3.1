FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS dotnetcore-sdk

# Copy csproj and restore as distinct layers
COPY Api.Application/Application.csproj ./Api.Application/
COPY Api.CrossCutting/CrossCutting.csproj ./Api.CrossCutting/
COPY Api.Data/Data.csproj ./Api.Data/
COPY Api.Domain/Domain.csproj ./Api.Domain/
COPY Api.Service/Service.csproj ./Api.Service/

RUN dotnet restore /Api.Application/Application.csproj

# Copy everything else and build
COPY . ./

# .NET Core Build and Publish
FROM dotnetcore-sdk AS dotnetcore-build
RUN dotnet publish ./Api.Application/Application.csproj -c Release -o /out

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS aspnetcore-runtime
WORKDIR /app
COPY --from=dotnetcore-build /out .
ENTRYPOINT ["dotnet", "Application.dll"]
