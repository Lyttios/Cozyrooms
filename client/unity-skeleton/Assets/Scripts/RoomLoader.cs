using UnityEngine;

[ExecuteAlways]
public class RoomLoader : MonoBehaviour
{
    [Header("Room settings")]
    public int roomWidth = 10;
    public int roomDepth = 8;
    public float floorHeight = 0f;

    [Header("Placeholder furniture")]
    public int placeholderCount = 6;
    public Vector2 furnitureScaleMin = new Vector2(0.4f, 0.4f);
    public Vector2 furnitureScaleMax = new Vector2(1.2f, 1.2f);

    void Start()
    {
        // Only create placeholders at runtime (Play mode) to avoid polluting Editor scenes repeatedly
        if (!Application.isPlaying) return;
        BuildRoom();
        SpawnPlaceholders();
    }

    void BuildRoom()
    {
        // Floor
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.name = "Floor";
        floor.transform.parent = this.transform;
        floor.transform.localScale = new Vector3(roomWidth / 10f, 1f, roomDepth / 10f);
        floor.transform.localPosition = new Vector3(0f, floorHeight, 0f);

        // Simple walls (cube stretched)
        CreateWall(new Vector3(0f, floorHeight + 1.5f, roomDepth / 2f), new Vector3(roomWidth, 3f, 0.2f)); // back
        CreateWall(new Vector3(0f, floorHeight + 1.5f, -roomDepth / 2f), new Vector3(roomWidth, 3f, 0.2f)); // front
        CreateWall(new Vector3(roomWidth / 2f, floorHeight + 1.5f, 0f), new Vector3(0.2f, 3f, roomDepth)); // right
        CreateWall(new Vector3(-roomWidth / 2f, floorHeight + 1.5f, 0f), new Vector3(0.2f, 3f, roomDepth)); // left
    }

    void CreateWall(Vector3 localPos, Vector3 size)
    {
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.name = "Wall";
        wall.transform.parent = this.transform;
        wall.transform.localPosition = localPos;
        wall.transform.localScale = size;
        var mr = wall.GetComponent<MeshRenderer>();
        if (mr != null) mr.sharedMaterial = new Material(Shader.Find("Standard")) { color = new Color(0.9f, 0.9f, 0.95f) };
    }

    void SpawnPlaceholders()
    {
        var rand = new System.Random(12345);
        for (int i = 0; i < placeholderCount; i++)
        {
            float x = (float)(rand.NextDouble() * roomWidth - roomWidth / 2f);
            float z = (float)(rand.NextDouble() * roomDepth - roomDepth / 2f);
            float sx = Mathf.Lerp(furnitureScaleMin.x, furnitureScaleMax.x, (float)rand.NextDouble());
            float sz = Mathf.Lerp(furnitureScaleMin.y, furnitureScaleMax.y, (float)rand.NextDouble());
            CreatePlaceholder(new Vector3(x, floorHeight + 0.5f, z), new Vector3(sx, 0.5f, sz), i);
        }
    }

    void CreatePlaceholder(Vector3 pos, Vector3 scale, int index)
    {
        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        g.name = $"Placeholder_Furniture_{index}";
        g.transform.parent = this.transform;
        g.transform.localPosition = pos;
        g.transform.localScale = scale;

        var mr = g.GetComponent<MeshRenderer>();
        if (mr != null)
        {
            mr.sharedMaterial = new Material(Shader.Find("Standard")) { color = Random.ColorHSV(0f,1f,0.6f,1f,0.6f,1f) };
        }

        // Add a simple marker component
        g.AddComponent<PlaceholderFurniture>();
    }
}
