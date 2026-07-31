Client (Unity) — quickstart notes

Recommended: Unity 2021/2022 LTS or newer.

Packages to consider:
- URP (lightweight render pipeline)
- Addressables (for furniture / streaming)
- Cinemachine (camera)
- Input System
- Mirror or use built-in transport + Netcode solution (or custom via WebSocket/SignalR client)

Create a `/client` Unity project and:
1. Create scene "Lobby" and "Room".
2. Implement a RoomLoader that requests room JSON from server and instantiates prefabs.
3. Keep avatar visuals modular: body, hair, clothing as separate addressable prefabs.

Example workflow:
- Devs add furniture prefabs + metadata (SKU, anchor points) into an Authoring tool.
- Server catalog stores item SKU and metadata; client uses SKU to load the correct prefab.
