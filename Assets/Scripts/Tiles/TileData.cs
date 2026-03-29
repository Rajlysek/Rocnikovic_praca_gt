using Unity.VisualScripting;
using UnityEngine;

public class TileData
{
    public bool isWet;
    public bool hasSeed;
    public ItemSO plantedSeed;
    public int daysPlanted;
    public Vector3Int positionOfTile;
    public int notWetFor = 0;
    
}
