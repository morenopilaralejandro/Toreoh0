using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGridLayerObstacles : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    private void Awake() 
    {
        Color color = tilemap.color;
        tilemap.color = ColorUtils.ChangeAlpha(color, 0f);
    }
}
