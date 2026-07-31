using UnityEngine;

public class PlaceholderFurniture : MonoBehaviour
{
    public string sku = "placeholder_sku";
    public string displayName = "Placeholder Furniture";

    // Runtime-only metadata (not persisted by this skeleton)
    void Reset()
    {
        // Default values for designers using the Inspector
        sku = "plc_chair_01";
        displayName = "Placeholder Chair";
    }
}
