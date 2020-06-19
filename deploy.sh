docker build -t VetsApiTest-image .

docker tag VetsApiTest-image registry.heroku.com/VetsApiTest/web


docker push registry.heroku.com/VetsApiTest/web

heroku container:release web -a VetsApiTest