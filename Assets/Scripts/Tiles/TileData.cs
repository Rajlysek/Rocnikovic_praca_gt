using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileData
{
    public ItemSO plantedSeed;

    public bool isWet;
    public bool hasSeed;
    public int daysPlanted;
    public bool isPickable;

    public Vector3Int positionOfTile;
    public int notWetFor = 0;
    public TileBase currentTileBase;
    public CurrentPhase seedCurrentPhase;
    
}
