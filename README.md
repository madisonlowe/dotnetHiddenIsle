GOAL

- Create a character sheet tracker for The Hidden Isle TTRPG by Sefirot. Eventually add other trackers to enable solitaire play, or running a campaign.

CHARACTER CREATION NOTES

To create a character:

- Pick your class and take a blank version of that class' character sheet.
- Look at the CORE SELF section. Determine your past:
  - Draw a vision card

AFTER MODEL CHANGES

```
dotnet ef migrations add <Name>
dotnet ef database update
```

LOCAL DATABASE CONFIGURATION

Docker Compose reads PostgreSQL credentials from `.env`.

The API and EF Core commands running directly on your machine use .NET User Secrets instead.

Follow these steps in order to set up both:

1. Create `.env` at the repo root (or update it if it already exists):

```
POSTGRES_USER=exampleUser
POSTGRES_PASSWORD=examplePassword
POSTGRES_DB=exampleDb
```

2. Start only the local PostgreSQL container:

```
docker compose up -d postgres
```

3. Confirm the container is running:

```
docker compose ps postgres
```

4. Set the matching local .NET User Secret connection string (replace values
   with the same ones from `.env`):

```
dotnet user-secrets set "ConnectionStrings:Default" "Host=localhost;Port=5432;Database=exampleDb;Username=exampleUser;Password=examplePassword"
```

5. Apply migrations to the local database:

```
dotnet ef database update
```

6. Run the API locally:

```
dotnet run
```

If you change `POSTGRES_USER`, `POSTGRES_PASSWORD`, or `POSTGRES_DB` in `.env`,
run `dotnet user-secrets set ...` again so local EF/API commands still connect.

RUNNING THE PROJECT (FE QUICKSTART)

If you just want to run the API locally and hit endpoints, this is the shortest path.

Prereqs:

- Docker Desktop running
- .NET 9 SDK installed
- Optional (only if you will create migrations): `dotnet tool install --global dotnet-ef`

First-time setup:

1. Start Postgres:

```
docker compose up -d postgres
```

2. Apply DB schema:

```
dotnet ef database update
```

3. Start API:

```
dotnet run
```

4. Use the API at:

- `http://localhost:5204`

Daily workflow:

1. Start DB container (can run it through Docker GUI, or use following):

```
docker compose up -d postgres
```

2. Start API:

```
dotnet run
```

COMMON COMMANDS

- Start DB only: `docker compose up -d postgres`
- See DB container status: `docker compose ps postgres`
- Stop containers: `docker compose down`

- Create a new migration: `dotnet ef migrations add <MigrationName>`
- Apply pending migrations: `dotnet ef database update`
- Run API: `dotnet run`
- Build project: `dotnet build`

NOTES

Do not run `docker compose down -v` unless you want to wipe data.
`docker compose down` keeps the named volume by default, so data remains.
