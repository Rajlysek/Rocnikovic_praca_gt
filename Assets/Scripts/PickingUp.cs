

using Unity.VisualScripting;
using UnityEngine;

using UnityEngine.Tilemaps;

public class PickingUp : MonoBehaviour
{
    public ActionsOfPlayer actionsOfPlayer;
    public Tilemap hoeTilamap;
    private Vector3Int FrontPlayerTile;
    public GameObject itemPrefab;
    GameObject itemInstance;
   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        FrontPlayerTile = actionsOfPlayer.FinalTilesPosition;
        if(hoeTilamap.HasTile(FrontPlayerTile) && Input.GetKeyDown(KeyCode.F))
        {
            if(FarmManager.farmedTiles[FrontPlayerTile].seedCurrentPhase == CurrentPhase.fourthPhase)
            {
                itemInstance = Instantiate(itemPrefab);
                itemInstance.transform.position = new Vector2(actionsOfPlayer.playerPosition.x, actionsOfPlayer.playerPosition.y);
                Item itemScript;
                itemScript = itemInstance.GetComponent<Item>();
                itemScript.itemSO = FarmManager.farmedTiles[FrontPlayerTile].plantedSeed.product;
                int randomValue = Random.Range(1, 4);
                Debug.Log(randomValue);
                itemScript.quantity = randomValue;
                itemScript.CreateItemOnGround();

            }
                
        }
        
    }
}
