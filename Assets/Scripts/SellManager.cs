using UnityEngine;
public class SellManager : MonoBehaviour
{
    public SellItemSlot[] SellableSlots;
    public PlayerStatsSO playerStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            SellPanelDisppear();
        }
    }
    public void SellPanelAppear()
    {
        SellableItemsInInventory();
        MenuManager.canOpenMenu = false;
        gameObject.SetActive(true);
    }  public void SellPanelDisppear()
    {
        MenuManager.canOpenMenu = true;
        gameObject.SetActive(false);
    }
    public void SellableItemsInInventory()
    {
        Debug.Log("Poèet vìcí v inventáøi: " + InventoryHoldingInfo.inventoryInfo.Count);
        int index = 0;
        foreach(var item in InventoryHoldingInfo.inventoryInfo)
        {
            if(index >= SellableSlots.Length)
            {
                break;
            }
            SellableSlots[index].GetInfoItem(InventoryHoldingInfo.inventoryInfo[index]);
            index++;

        }
    }
}
