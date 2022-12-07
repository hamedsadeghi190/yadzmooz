run this command on Infastucture.EndPint

dotnet publish -c Release

these commands are for running your docker image, you ca change the ports in dockerfile

docker build -t skillsapp .
docker run -d -p 8080:5001 --name skills skillsapp
