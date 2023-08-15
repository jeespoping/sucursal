FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR webapp

EXPOSE 80
EXPOSE 5000

COPY . .
WORKDIR /webapp/ProyectoSucursal.AplicacionWeb
RUN dotnet restore

WORKDIR /webapp/ProyectoSucursal.AplicacionWeb
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /webapp/ProyectoSucursal.AplicacionWeb
COPY --from=build /webapp/ProyectoSucursal.AplicacionWeb/out .
ENTRYPOINT ["dotnet", "ProyectoSucursal.AplicacionWeb.dll"]