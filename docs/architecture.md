# Architecture (high level)

Components
- Client (Unity): renders 3D rooms, avatars, and provides build/buy UIs. Connects to server over WebSocket + REST.
- Server (ASP.NET Core): authoritative game server handling room state, trades, inventory, and persistence.
- DB (Postgres): persistent players, rooms, items, inventories, trades.
- Cache (Redis): ephemeral room state, presence, rate-limiting.
- Asset pipeline: developers publish furniture as prefabs/metadata. Client uses an addressable system to load items.

Key design choices
- Room-based instancing: server creates lightweight room sessions; clients load room state when joining.
- Server-authoritative actions: placement, trade settlement, coin transfers validated server-side.
- No user-uploaded models (dev-created assets only) to simplify moderation/performance.
