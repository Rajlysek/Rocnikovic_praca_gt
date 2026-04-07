using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileData
{
    public bool isWet;
    public bool hasSeed;
    public ItemSO plantedSeed;
    public int daysPlanted;
    public Vector3Int positionOfTile;
    public int notWetFor = 0;
    public TileBase currentTileBase;
    
}
