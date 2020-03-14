FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS dotnetcore-sdk
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY source/Api.Application/Application.csproj ./Api.Application/
COPY source/Api.CrossCutting/CrossCutting.csproj ./Api.CrossCutting/
COPY source/Api.Data/Data.csproj ./Api.Data/
COPY source/Api.Domain/Domain.csproj ./Api.Domain/
COPY source/Api.Service/Service.csproj ./Api.Service/

RUN dotnet restore ./Api.Application/Application.csproj

# Copy everything else and build
COPY source ./

# .NET Core Build and Publish
FROM dotnetcore-sdk AS dotnetcore-build
RUN dotnet publish ./Api.Application/Application.csproj -c Release -o /out

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS aspnetcore-runtime
WORKDIR /app
COPY --from=dotnetcore-build /out .
EXPOSE 8080/tcp
ENV ASPNETCORE_URLS http://*:8080
ENV ASPNETCORE_ENVIRONMENT docker
ENTRYPOINT ["dotnet", "Application.dll"]