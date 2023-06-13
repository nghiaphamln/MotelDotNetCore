FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR "/"
COPY ["MotelDotNetCore/MotelDotNetCore.csproj", "MotelDotNetCore/"]
RUN dotnet restore "MotelDotNetCore/MotelDotNetCore.csproj"
COPY . .
WORKDIR "/MotelDotNetCore"
RUN dotnet build "MotelDotNetCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MotelDotNetCore.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#ENTRYPOINT ["dotnet", "MotelDotNetCore.dll"]
ENTRYPOINT ["sh", "-c", "openssl pkcs12 -export -in /https/server.crt -inkey /https/server.key -out /https/server.pfx -password pass:; dotnet MotelDotNetCore.dll"]

