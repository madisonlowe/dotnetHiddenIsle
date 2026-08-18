GOAL

- Create a character sheet tracker for The Hidden Isle TTRPG by Sefirot. Eventually add other trackers to enable solitaire play or running a campaign.

DONE

TODO

CHARACTER MODEL NOTES
To create a character:

- Pick your class and take a blank version of that class' character sheet.
- Look at the CORE SELF section. Determine your past:
  - Draw a vision card

CHARACTER MODEL

- CLASS & Class Description (enum, string)
- Name, Age, Culture, Look (strings)
- ABILITY SUITS:
  - Skirmish, Convince, Study, XP, Harm
  - Unleash, Perform, Channel, XP, Harm
  - Slip, Soothe, Mingle, XP, Harm
  - Finesse, Bargain, Survey, XP, Harm
- INVENTORY: Load (5/5), Items
- ABILITIES: Ability, XP (9/9)
- Magical Proficiencies (1/4): Adept, Master
- Magical Sources
- CONTACTS: Affection (6/6), Name, Description, Card, Land, Distance (3/3)
- BURDEN: +1 to challenge cards
- VICE: +1 to challenge cards
- VIRTUE: +3 to card numerals
- IDEAL: -1 to challenge cards, +3 to card numerals
- CORE SELF:
  - As a child, I solved problems by...
  - As an adult, I survived / flourished by...
  - Fulfilled virtues (array)
- NOTES (string, desc)

AFTER MODEL CHANGES:

```
dotnet ef migrations add <Name>
dotnet ef database update
```

Important notes:

Do not run docker compose down -v unless you want to wipe data.
docker compose down keeps the named volume by default; data remains.

What happened with commands:

`dotnet ef migrations list` now builds the model successfully.
`docker compose up -d postgres` started your local DB container.
`dotnet ef migrations add InitialCreate` succeeded.
`dotnet ef database update` succeeded and applied InitialCreate.
You can now begin testing against the local DB.

Next steps:

Run API locally: dotnet run
Hit your endpoints (for example from dotnetHiddenIsle.http)
Optional: I can also wire auto-migrate on startup in Development so schema updates apply automatically during local runs.
