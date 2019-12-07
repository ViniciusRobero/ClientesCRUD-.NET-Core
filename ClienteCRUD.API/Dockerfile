FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ClienteCRUD.API/ClienteCRUD.API.csproj ClienteCRUD.API/
COPY ClienteCRUD.DTO/ClienteCRUD.DTO.csproj ClienteCRUD.DTO/
COPY ClienteCRUD.Domain/ClienteCRUD.Domain.csproj ClienteCRUD.Domain/
COPY ClienteCRUD.Infra/ClienteCRUD.Infra.csproj ClienteCRUD.Infra/
COPY ClienteCRUD.Service/ClienteCRUD.Service.csproj ClienteCRUD.Service/
COPY ClienteCRUD.Validations/ClienteCRUD.Validation.csproj ClienteCRUD.Validations/
RUN dotnet restore ClienteCRUD.API/ClienteCRUD.API.csproj
COPY . .
WORKDIR /src/ClienteCRUD.API
RUN dotnet build ClienteCRUD.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ClienteCRUD.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ClienteCRUD.API.dll"]
