using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public GameObject WaterPanel;
    private RectTransform rectTransform;
    public DaysManagerSO daysManager;
    public PlayerStatsSO playerStats;
    void Awake()
    {
        rectTransform = WaterPanel.GetComponent<RectTransform>();
        if (StaminaManager.firstStart)
        {
            playerStats.water = 100;

        }
        UpdateWaterUI();
           
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void WaterUsed(int usedWater)
    {
        if (playerStats.water != 0)
        {
            playerStats.water -= usedWater;
            Debug.Log(playerStats.water);
            UpdateWaterUI();
        }
    }
    public void WaterReplenish()
    {
        
        playerStats.water = 100;
        UpdateWaterUI();
        
    }
    public void UpdateWaterUI()
    {
        int currentWaterBar = 100 - playerStats.water;
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -currentWaterBar);
    }
}
