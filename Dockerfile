# stage 1 -- build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

# copy csproj and restore, this allows docker to
# cache the intermedaite image
WORKDIR /app
COPY ./src/*.csproj ./
RUN dotnet restore

# copy everything else and build
COPY ./src/ ./
RUN find -type d -name bin -prune -exec rm -rf {} \; && find -type d -name obj -prune -exec rm -rf {} \;
RUN dotnet publish -c Release -o dist

# stage 2 -- copy to dotnet runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app

# copy the aspnetcore app
COPY --from=build /app/dist/ ./

# heroku sets the PORT variable at runtime, then only forwards connections to that port number.
# https://devcenter.heroku.com/articles/container-registry-and-runtime#get-the-port-from-the-environment-variable
ENV PORT=5000

CMD ASPNETCORE_URLS=http://+:$PORT dotnet T3.Communications.dll
