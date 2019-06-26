dotnet publish -c prod
dotnet publish -c release

docker build -t erpdataapp .

docker
docker info
docker search aspnetcore
docker images

https://devblogs.microsoft.com/premier-developer/running-a-net-core-web-application-in-docker-container-using-docker-desktop-for-windows/

docker run -d -p 8080:80 –name erpdata erpdataapp

http://localhost:8080/
