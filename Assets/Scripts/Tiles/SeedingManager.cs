
using UnityEngine;
using UnityEngine.UI;

public class SeedingManager : MonoBehaviour
{
    public ActionsOfPlayer actionsOfPlayer;
    public FarmManager farmManager;
    public GameObject seedButton;
    public GameObject inventoryScroll;
    public Button button;
    public Vector3Int FrontTilePosition;
    public SeedingScrollView seedingScrollView;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
       
        FrontTilePosition = actionsOfPlayer.FinalTilesPosition;

        
        button = seedButton.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3Int FrontTilePosition = actionsOfPlayer.FinalTilesPosition;

        if (farmManager.buttonSearch(FrontTilePosition))
        {
            seedButton.SetActive(true);
        }
        else
        {
            seedButton.SetActive(false);
            inventoryScroll.SetActive(false);
        }
    }
    void TaskOnClick()
    {
       
        if (!inventoryScroll.activeSelf)
        {
            
            inventoryScroll.SetActive(true);
            seedingScrollView.GetSeedableItems();
        }
        else 
        {
            
            inventoryScroll.SetActive(false);
        }
    }
    public void SeedOnTile(ItemSO seedToSeed)
    {
        Vector3Int FrontTilePosition = actionsOfPlayer.FinalTilesPosition;
        farmManager.SeedingOnTile(seedToSeed, FrontTilePosition);
    }
}
