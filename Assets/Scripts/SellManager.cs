using UnityEngine;
using UnityEngine.Rendering;
public class SellManager : MonoBehaviour
{
    public SellItemSlot[] SellableSlots;
    public PlayerStatsSO playerStats;
    public InventoryManager inventoryManager;
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
        for (int i = 0; i < inventoryManager.itemSlot.Length; i++) 
        {
            inventoryManager.itemSlot[i].EmptySlot();
        }
        inventoryManager.LoadInventory();
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
            if(InventoryHoldingInfo.inventoryInfo[index] != null)
            {
                SellableSlots[index].GetInfoItem(InventoryHoldingInfo.inventoryInfo[index], InventoryHoldingInfo.quantityOfItemsInSlots[index]);
            }
            else
            {
                SellableSlots[index].DeleteItemInfo();
                
            }
            index++;

        }
    }
    public void CheckIfSold()
    {
        foreach(var item in SellableSlots)
        {
            
        }
    }
}
