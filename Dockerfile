FROM microsoft/dotnet:latest

WORKDIR /root/
ADD . ./app/
WORKDIR /root/app/

RUN dotnet restore
RUN dotnet build

CMD ["dotnet", "run"]

EXPOSE 8080