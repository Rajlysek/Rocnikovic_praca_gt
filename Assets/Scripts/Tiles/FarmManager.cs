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
    [SerializeField] private TileBase hoedDirtTileAloneSeed;
    [SerializeField] private TileBase hoedDirtTileWetAloneSeed;
    public DaysManagerSO daysManager;
    List<Vector3Int> tilesToRemove = new List<Vector3Int>();
    //event
  
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
    public void AddTileSprite(Vector3Int tilePosition,TileBase newTileSprite)
    {
        farmedTiles[tilePosition].currentTileBase = newTileSprite;
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
            newTilemap.SetTile(pos, item.Value.currentTileBase);
        }
    }
    public void SeedingOnTile(ItemSO seedToSeed, Vector3Int positionOfTile)
    {
    
        var currentTile = farmedTiles[positionOfTile];
        currentTile.plantedSeed = seedToSeed;

        currentTile.hasSeed = true;

        currentTile.seedCurrentPhase = CurrentPhase.seed;

       
    }
    private void OnEnable()
    {
       
        daysManager.OnDayChange += GrowingSeeds;
    }
    private void OnDisable()
    {
        daysManager.OnDayChange -= GrowingSeeds;
    }
    private void GrowingSeeds()
    {
        
        foreach (var item in farmedTiles)
        {
            Vector3Int pos = item.Key;
            if(item.Value.notWetFor == 2 && item.Value.hasSeed)
            {
                tilesToRemove.Add(pos);
                continue;
            }
            else if (item.Value.notWetFor == 1 && item.Value.hasSeed == false)
            {
                tilesToRemove.Add(pos);
                continue;
            }
            else if (item.Value.isWet == false)
            {
                item.Value.notWetFor++;
                continue;
            }

            if (item.Value.hasSeed)
            {
                item.Value.daysPlanted++;
                if(item.Value.seedCurrentPhase < CurrentPhase.fourthPhase)
                { 
                    item.Value.seedCurrentPhase++;
                    int currentIndex = (int)item.Value.seedCurrentPhase;
                    item.Value.currentTileBase = item.Value.plantedSeed.Phase[currentIndex-1];

                }
                //else if (item.Value.daysPlanted == item.Value.plantedSeed.timeToGrow)
                //{
                //    item.Value.seedCurrentPhase = CurrentPhase.fourthPhase;
                //    item.Value.currentTileBase = item.Value.plantedSeed.fourthPhase;
                //    Debug.Log("Fully Grown");
                //}
                else if(item.Value.seedCurrentPhase == CurrentPhase.fourthPhase)
                {
                    item.Value.currentTileBase = item.Value.plantedSeed.fourthPhase;
                    
                    Debug.Log("IsGrown");
                }
               
            }
            else
            {
                item.Value.currentTileBase = hoedDirtTileAlone;
            }
                item.Value.isWet = false;
        }
        foreach(var posToRemove in tilesToRemove)
        {
            farmedTiles.Remove(posToRemove);
        }
        
    }
    public void SeedPickedUp(Vector3Int seedPosition)
    {
        if (farmedTiles.ContainsKey(seedPosition))
        {
            
            HoeTilemap.SetTile(seedPosition, null);
            if (farmedTiles.Remove(seedPosition))
            {
                Debug.Log("Tile removed from farmedTiles");
            }
        }
    }
}
