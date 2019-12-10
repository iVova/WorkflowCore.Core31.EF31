#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Test.WorkflowCore.Core31.EF31/Test.WorkflowCore.Core31.EF31.csproj", "Test.WorkflowCore.Core31.EF31/"]
RUN dotnet restore "Test.WorkflowCore.Core31.EF31/Test.WorkflowCore.Core31.EF31.csproj"
COPY . .
WORKDIR "/src/Test.WorkflowCore.Core31.EF31"
RUN dotnet build "Test.WorkflowCore.Core31.EF31.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test.WorkflowCore.Core31.EF31.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test.WorkflowCore.Core31.EF31.dll"]