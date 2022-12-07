  #FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
  FROM mcr.microsoft.com/dotnet/core/sdk:3.1
  #COPY . .
  #RUN dotnet publish -c Release ./Infrastructure.MobileEndPoint.csproj
  COPY bin/Release/netcoreapp3.1/publish/ App/
  WORKDIR /App
  ENV ASPNETCORE_URLS="http://*:5001"
  ENTRYPOINT ["dotnet", "Infrastructure.MobileEndpoint.dll"]

  

