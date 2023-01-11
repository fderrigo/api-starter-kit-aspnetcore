# Starter kit per la pubblicazione di API interoperabili in C# (aspnetcore 7.0)

[![.NET](https://github.com/fderrigo/api-starter-kit-aspnetcore/actions/workflows/dotnet.yml/badge.svg)](https://github.com/fderrigo/api-starter-kit-aspnetcore/actions/workflows/dotnet.yml)

Questo repository contiene il template di un'API interoperabile scritta in C#.

## Contenuto

- Un progetto di esempio in src/Core_SK
- Una directory src/openapi con le specifiche


## Istruzioni

Gli step per la creazione di API interoperabili sono:

1. scrivere le specifiche in formato OpenAPI v3 partendo dall' esempio in `openapi`;

2. scrivere o generare il codice a partire dalle specifiche attraverso i tool di swagger

3. scrivere i metodi dell'applicazione

### Scrivere le specifiche

Le specifiche devono essere scritte in formato OpenAPIv3
e rispettando le [Linee Guida di interoperabilità](https://docs.italia.it/italia/piano-triennale-ict/lg-modellointeroperabilita-docs).

- [Introduzione ad OpenAPI](https://docs.google.com/presentation/d/1blql0E_zcbq7r-wzmslgJPiW7ELkYlIn9_fqIVEXr4A)
- [REST nel nuovo modello di interoperabilità](https://docs.google.com/presentation/u/1/d/1L6R4ZKhLoZAPEmai1KSED1nrq0GNrx3-TU53sGhfrO8/)


## Run

Linux/OS X:

```
sh build.sh
```

Windows:

```
build.bat
```

Una volta eseguito all'Url [https://localhost:5001/swagger/1.0.0/swagger.json](https://localhost:5001/swagger/1.0.0/swagger.json) sarà disonibile il file con le specifiche  in formato OpenAPIv3

Gli endpoint dell' API di test saranno disponibili all'Url

- https://localhost:5001/datetime/v1/echo
- https://localhost:5001/datetime/v1/status


### Run con docker-compose

Si può avviare il progetto con il comando

```
docker-compose up
```


## Prerequisiti

Intallazione [ASP.NET Core Runtime 7.0.0](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).





