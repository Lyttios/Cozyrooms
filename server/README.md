Server (ASP.NET Core) — quickstart

Prereqs: .NET 7/8 SDK, Docker for DB, Redis.

1. Start DB & Redis:
   docker compose up -d

2. Run DB init (example):
   psql "host=localhost port=5432 user=cozy password=cozy_pass dbname=cozydb" -f scripts/init_db.sql

3. Build & run server:
   cd server
   dotnet run

Notes
- Use WebSockets for real-time room updates (SignalR is a good option for C#).
- Use EF Core or Dapper for DB access.
- Consider separating an HTTP API (account, catalog) from a persistent room server (Socket/rooms).
