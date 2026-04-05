using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmManager : MonoBehaviour
{

    static public Dictionary<Vector3Int, TileData> farmedTiles = new Dictionary<Vector3Int, TileData>();
    public static FarmManager instance;
    [SerializeField] private Tilemap HoeTilemap;
    [SerializeField] private TileBase hoedDirtTileAlone;
    [SerializeField] private TileBase hoedDirtTileWetAlone;
    //event
    [SerializeField] private DaysManagerSO daysManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void Awake()
    {
        if (instance != null)
        {
            RedrawTilemap(HoeTilemap);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void AddTileData(Vector3Int tilePosition)
    {
        if (!farmedTiles.ContainsKey(tilePosition))
        {
            TileData newTile = new TileData();
            farmedTiles.Add(tilePosition, newTile);
            farmedTiles[tilePosition].positionOfTile = tilePosition;
            newTile.isWet = false;
        }

    }
    public void WettingTheTile(Vector3Int tilePosition)
    {
        if (farmedTiles.ContainsKey(tilePosition))
        {
            farmedTiles[tilePosition].isWet = true;
        }

    }
    public bool buttonSearch(Vector3Int tilePosition)
    {
        if (farmedTiles.ContainsKey(tilePosition) && !farmedTiles[tilePosition].hasSeed)
        {
            return true;
        }
        else return false;
    }
    //method for redrawing a map after exiting and the again appearing in the scene
    public void RedrawTilemap(Tilemap newTilemap)
    {
        this.HoeTilemap = newTilemap;
        foreach (var item in farmedTiles)
        {
            Vector3Int pos = item.Key;
            if (item.Value.isWet)
            {
                newTilemap.SetTile(pos, hoedDirtTileWetAlone);
            }
            else
            {
                newTilemap.SetTile(pos, hoedDirtTileAlone);
            }
        }
    }
    public void SeedingOnTile(ItemSO seedToSeed, Vector3Int positionOfTile)
    {
        farmedTiles[positionOfTile].plantedSeed = seedToSeed;

        farmedTiles[positionOfTile].hasSeed = true;
    }
}
