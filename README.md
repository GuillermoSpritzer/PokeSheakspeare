# PokeSheakspeare

Fun API project to express pokemon descriptions with sheakspeare type of writing

## To run locally, follow next steps


System requirements:

.Net Core v3.1 --- installation ( https://dotnet.microsoft.com/download/dotnet-core/3.1 )

Once installed donwload repository and open the folder on console

```
$ cd ../Pokesheakspeare/Pokesheakspeare

$ dotnet build

$ dotnet run
```

Application will run on port 5001:8080

You can test it going on https://localhost:5001/pokemon/ditto


## To run on a container in docker

System requirements:

Docker --- installation ( https://www.docker.com/get-started ) or for mac $ brew install docker

Once installed download the repository and open the folder on console

```
$ cd ../PokeSheakspeare

$ docker build -t pokesheakspeare .

$ docker run --publish 5000:80 --detach --name pokesheakspeareContainer1 pokesheakspeare
```

Application will run on port 5000:80

you can test it going on http://localhost:5000/pokemon/ditto

