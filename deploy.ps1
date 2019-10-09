minikube start
minikube docker-env | Invoke-Expression
docker-compose build
docker-compose up -d jeppesen
docker commit $(docker-compose ps -q jeppesen) jeppesen_service
kubectl create -f .\Jeppesen\deployment.yml