#!/bin/sh
docker run -d --name redis -p 6379:6379 redis

until docker exec -it redis redis-cli ping
do 
    echo "waiting for redis"
    sleep 2
done