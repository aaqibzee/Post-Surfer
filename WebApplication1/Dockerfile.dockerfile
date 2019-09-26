FROM micosoft/dotnet:2.2 -sdk  as build 
ARG BUILDCONFIG= RELEASE 
ARG VERSION= 1.0.0

COPY Post Surfer.csproj /build/

RUN dotnet restore ./build/Post Surfer.csproj

COPY ../build/
WORKDIR /build/
RUN dotnet publish ./Post Surfer.csproj -C $BUILDCONFIG -o out /p:VERSION=$VERSION

FROM micosoft/dotnet:2.2 -aspnetcore-runtime
WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT ["dotnet","Post Surfer.dll"]