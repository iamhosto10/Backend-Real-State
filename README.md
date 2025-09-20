# Million RealEstate - Backend (Skeleton)

This repository contains a complete backend skeleton (C# .NET 8) implementing the technical test requirements.

## What is included

- `src/Million.RealEstate.Api` - API project (Program.cs, Controllers)
- `src/Million.RealEstate.Application` - DTOs and interfaces
- `src/Million.RealEstate.Domain` - Domain entity
- `src/Million.RealEstate.Infrastructure` - Mongo repository example (uses MongoDB.Driver)
- `tests` - NUnit sample unit test
- `docker-compose.yml` - app + mongo
- `Dockerfile` - for the API
- `seed/seed.json` - sample seed data
- `backup/backup.gz` - gzipped JSON backup produced from `seed.json`
- `postman_collection.json` - example curl and sample requests

## How to run (locally)

Prerequisites: .NET 8 SDK, Docker (for docker-compose).

Run with docker-compose:

```bash
docker-compose up --build
```

Or run API locally (requires Mongo running locally):

- Set `MongoSettings__ConnectionString` to your Mongo instance.
- `dotnet run --project src/Million.RealEstate.Api`

## Tests

Unit tests are included under `tests`. Run with:

```bash
dotnet test
```
