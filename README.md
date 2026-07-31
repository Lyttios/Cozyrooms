# CozyRooms — 3D Social Sandbox (starter repo)

A minimal starter scaffold for a social decorating game inspired by Habbo + The Sims.

Goals:
- Room-based multiplayer (server authoritative)
- Dev-created furniture & assets
- Simple economy and trading
- Focus on building, decorating, socializing

Quick start (local prototype)
1. Install Docker + Docker Compose.
2. Run: `docker compose up -d` (starts Postgres & Redis).
3. Create a Unity project in `/client` (see /client/README.md).
4. Start the server in `/server` (see /server/README.md).

Repository layout
- /client           -> Unity project (avatars, build/buy UI, room loader)
- /server           -> ASP.NET Core web & socket server (authoritative room state)
- /docs             -> design & architecture notes
- /scripts          -> DB init and helpers
- docker-compose.yml
- README.md, LICENSE, .gitignore
