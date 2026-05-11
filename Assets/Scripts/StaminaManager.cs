using System.ComponentModel;
using Unity.XR.Oculus.Input;
using UnityEngine;
using UnityEngine.UIElements;

public class StaminaManager : MonoBehaviour
{
    public static bool firstStart = true;
    public PlayerStatsSO playerStats;
    public GameObject StaminaPanel;
    private RectTransform rectTransform;
    public DaysManagerSO daysManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rectTransform = StaminaPanel.GetComponent<RectTransform>();
        if (firstStart)
        {
            playerStats.stamina = 100;
            playerStats.money = 5;
            firstStart = false;
        }
       
        UpdateStaminaUi();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StaminaUsed(int usedStamina)
    {
        if(playerStats.stamina != 0)
        {
            playerStats.stamina -= usedStamina;
           //Debug.Log(playerStats.stamina);
            UpdateStaminaUi();
        }
    }
    private void OnEnable()
    {
        daysManager.OnDayChange += staminaReplenish;
    
    }
    private void OnDisable()
    {
        daysManager.OnDayChange -= staminaReplenish; 
    }
    public void staminaReplenish()
    {
       
        playerStats.stamina = 100;
        UpdateStaminaUi();
        
    }
    public void UpdateStaminaUi()
    {
        int currentStaminaBar = 100 - playerStats.stamina;
        rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -currentStaminaBar);
    }
}
