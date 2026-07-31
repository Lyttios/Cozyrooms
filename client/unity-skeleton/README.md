# Unity skeleton — minimal Assets for CozyRooms

This folder contains a minimal Unity Assets/Scripts scaffold you can drop into a new Unity project. It includes a RoomLoader script that creates a simple Room scene at runtime using placeholder geometry (cubes) so you don't need prefabs to test functionality.

How to use
1. Create a new Unity project (recommended: Unity 2021.3 LTS or later).
2. In your project folder, copy the contents of `client/unity-skeleton/Assets` into the project's `Assets/` folder.
3. Open Unity and create a new Scene named "Room".
4. Create an empty GameObject in the scene named `RoomRoot`.
5. Attach the `RoomLoader` component (Assets/Scripts/RoomLoader.cs) to `RoomRoot`.
6. Press Play — the RoomLoader will instantiate a floor and placeholder furniture cubes.

Notes
- This skeleton intentionally avoids binary Scene or prefab files: instead it creates everything at runtime so the files are portable across Unity versions.
- Use this as a starting point to wire networking and catalog-driven instancing.
