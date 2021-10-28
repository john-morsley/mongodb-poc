```
docker run -p 27017:27017 --name morsley_mongo mongo
```

or 

```
docker run -p 27017:27017 -v ~/mongo:/data/db --name morsley_mongo mongo
```

To run in detached mode:
```
docker run -d ...
```

To enter into interactive mode: 
```
docker exec -it morsley_mongo mongo
```

To see DBs:
```
show dbs
```

UI Admin
```bash
docker run -e ME_CONFIG_MONGODB_SERVER=morsley -p 8084:8081 mongo-express
```

[http://localhost:3000](http://localhost:3000)