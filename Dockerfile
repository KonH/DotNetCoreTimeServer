FROM microsoft/dotnet:latest

ENV TS_URL http://*:8080
ENV TS_PORT 8080
WORKDIR /root/
ADD . ./app/
WORKDIR /root/app/

RUN dotnet restore
RUN dotnet build

CMD dotnet run ${TS_URL}

EXPOSE ${TS_PORT}
