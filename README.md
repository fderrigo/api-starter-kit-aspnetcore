# API Starter Kit — ASP.NET Core

[![.NET](https://github.com/fderrigo/api-starter-kit-aspnetcore/actions/workflows/dotnet.yml/badge.svg)](https://github.com/fderrigo/api-starter-kit-aspnetcore/actions/workflows/dotnet.yml)
[![License: Apache 2.0](https://img.shields.io/badge/License-Apache_2.0-blue.svg)](LICENSE)
[![.NET](https://img.shields.io/badge/.NET-7.0-512BD4.svg)](https://dotnet.microsoft.com/download/dotnet/7.0)
[![OpenAPI](https://img.shields.io/badge/OpenAPI-3.0-6BA539.svg)](src/openapi/swagger.json)

Template per la pubblicazione di **API REST interoperabili** in C# / ASP.NET Core,
conformi alle [Linee Guida del Modello di Interoperabilità](https://docs.italia.it/italia/piano-triennale-ict/lg-modellointeroperabilita-docs)
di AgID / Team Digitale.

> Progetto originale di Filippo D'Errigo, in seguito **forkato nel repository
> ufficiale di [Team Digitale](https://github.com/teamdigitale/api-starter-kit-aspnetcore)**
> nell'ambito del Piano Triennale ICT.

---

## Cos'è

Punto di partenza per chi deve esporre servizi REST conformi agli standard della
Pubblica Amministrazione italiana. L'approccio è **design-first**:

1. **Specifiche** — si scrivono le API in formato OpenAPI v3 rispettando le linee
   guida di interoperabilità (partendo dall'esempio in `src/openapi/`).
2. **Generazione** — si genera lo scaffolding del codice dalle specifiche con i
   tool Swagger / OpenAPI Generator.
3. **Implementazione** — si scrivono i metodi applicativi nei controller.

Il kit include un servizio dimostrativo **"Ora esatta"** che mostra le pratiche
richieste in produzione: gestione errori `problem+json` (RFC 7807) e header di
rate limiting (`X-RateLimit-*`, `Retry-After`).

## Endpoint di esempio

| Metodo | Path                   | Descrizione                                             |
|--------|------------------------|--------------------------------------------------------|
| `GET`  | `/datetime/v1/echo`    | Ritorna un timestamp del server in formato RFC5424.    |
| `GET`  | `/datetime/v1/status`  | Ritorna lo stato del servizio.                         |

Entrambi gli endpoint, a scopo didattico, ritornano **errori simulati su base
randomica** (`503 Service Unavailable`, `429 Too Many Requests`) per testare la
resilienza dei client e la corretta gestione degli header di throttling.

Le specifiche OpenAPI generate sono disponibili a runtime su:

```
https://localhost:5001/swagger/1.0.0/swagger.json
```

## Prerequisiti

- [.NET SDK 7.0](https://dotnet.microsoft.com/download/dotnet/7.0)
- (opzionale) Docker + Docker Compose

## Avvio

### Locale

```bash
# Linux / macOS
sh build.sh

# Windows
build.bat
```

In alternativa, direttamente con la CLI .NET:

```bash
dotnet run --project src/Core_SK/Core_SK.csproj
```

API disponibili su `https://localhost:5001` (HTTPS) e `http://localhost:5000`.

### Docker Compose

```bash
docker-compose up
```

## Struttura del progetto

```
.
├── src/
│   ├── Core_SK/              # Applicazione ASP.NET Core
│   │   ├── Controllers/      # Implementazione degli endpoint
│   │   ├── Models/           # Modelli (Timestamps, Problem)
│   │   ├── Filters/          # Filtri Swagger (basePath, header, mime-type)
│   │   ├── Attributes/       # Attributi custom per OpenAPI
│   │   └── Startup.cs        # Configurazione servizi e pipeline
│   └── openapi/              # Specifiche OpenAPI v3
├── build.sh / build.bat      # Script di build & run
├── docker-compose.yml
├── LICENSE                   # Apache-2.0
└── NOTICE
```

## Riferimenti

- [Linee Guida sul Modello di Interoperabilità](https://docs.italia.it/italia/piano-triennale-ict/lg-modellointeroperabilita-docs)
- [RFC 7807 — Problem Details for HTTP APIs](https://datatracker.ietf.org/doc/html/rfc7807)
- [OpenAPI Specification 3.0](https://spec.openapis.org/oas/v3.0.3)

## Licenza

Distribuito con licenza **[Apache License 2.0](LICENSE)** — Copyright © 2026 Filippo D'Errigo.

Lo scaffolding sotto `src/Core_SK` (attributi, filtri, stub dei controller) è
stato originariamente prodotto dai tool di generazione Swagger / OpenAPI a partire
da una specifica OpenAPI v3 — vedi [`NOTICE`](NOTICE) per i dettagli.

## Autore

**Filippo D'Errigo** — <filippo.derrigo@gmail.com>
