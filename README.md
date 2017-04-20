# DotNetCoreTimeServer
Simple server that returns current time in UTC format like "2016-12-25T14:12:33+00:00" (look at [it](https://konhit.xyz/dotnet_time/)).

# API
Request for **/time** returns UTC time in string format.

# Usage
- Run directly using ```dotnet run``` (optional arguments - array of URLs, "http://*:8080" by default)
- Use Docker:
	- ```docker pull konh/timeserver:latest```
	- ```docker run -i -t -p 8080:8080 konh/timeserver:latest```
	- You can customize port and url with additional commands like: ```docker run -i -t -p 80:80 -e TS_PORT=80 -e TS_URL=http://*:80 konh/timeserver:latest```
	- Or you can create your own image from Dockerfile with custom settings

