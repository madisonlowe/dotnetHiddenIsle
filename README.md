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

NOTES

Do not run `docker compose down -v` unless you want to wipe data.
`docker compose down` keeps the named volume by default; data remains.

`docker compose up -d postgres` starts local DB container.
`dotnet ef migrations add MigrationsFileName` makes a new migration.
`dotnet ef database update` applies changes after migration.

`dotnet run` to run API locally after you've opened Docker.
