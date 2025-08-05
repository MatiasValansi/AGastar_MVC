FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR webapp

EXPOSE 5000

# COPI0 EL ARCHIVO PRINCIPAL DEL PROYECTO
COPY ./*.csproj ./
RUN dotnet restore #Verifica que el proyecto posee todas las dependencias que necesita

# COPIO EL RESTO DE LOS ARCHIVOS DEL PROYECTO
COPY . .
RUN dotnet publish -c Release -o out

# CONSTRUYO UNA IMAGEN
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR webapp
EXPOSE 80
COPY --from=build /webapp/out .
ENTRYPOINT ["dotnet","/AGastar_MVC.dll"]