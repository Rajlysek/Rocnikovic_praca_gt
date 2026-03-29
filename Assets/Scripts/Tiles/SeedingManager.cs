
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
    int buttonClicked = 0;
    
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
        else seedButton.SetActive(false);

    }
    void TaskOnClick()
    {
       
        if (buttonClicked ==0)
        {
            buttonClicked += 1;
            inventoryScroll.SetActive(true);
        }
        else if (buttonClicked == 1)
        {
            buttonClicked = 0;
            inventoryScroll.SetActive(false);
        }
    }
}
