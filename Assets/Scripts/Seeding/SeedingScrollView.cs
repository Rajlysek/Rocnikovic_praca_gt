using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SeedingScrollView : MonoBehaviour
{
    ItemSO itemSO;
    public InventoryHoldingInfo inventoryInfoDic;
    public InventoryManager inventoryManager;
    public SeedingScrollViewSlot[] seedingSlots;
    int currentSlot = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    private void Start()
    {
        
    }
    public void GetSeedableItems()
    {   for(int i = 0; i < seedingSlots.Length; i++)
        {
            seedingSlots[i].ClearSlot();
           
        }
        currentSlot = 0;
        for (int i = 0; i < InventoryHoldingInfo.inventoryInfo.Count; i++)
        {
            if (InventoryHoldingInfo.inventoryInfo[i] != null)
            {
                itemSO = InventoryHoldingInfo.inventoryInfo[i];
                if (itemSO.isSeedable)
                {
                    if (currentSlot < seedingSlots.Length)
                    {
                        seedingSlots[currentSlot].GetItemInfo(InventoryHoldingInfo.inventoryInfo[i], InventoryHoldingInfo.quantityOfItemsInSlots[i]);
                        currentSlot++;
                    }


                }
            }
        }


    }
    public void SeedOnClick(ItemSO ItemSO)
    {
        int position = 0;
        for (int i = 0; i < InventoryHoldingInfo.inventoryInfo.Count; i++)
        { 
            itemSO = InventoryHoldingInfo.inventoryInfo[i];
            if(itemSO == ItemSO)
            {
                position = i;
                break;
            }
        }
        InventoryHoldingInfo.quantityOfItemsInSlots[position] -= 1;
        Debug.Log(InventoryHoldingInfo.quantityOfItemsInSlots[position]);
        inventoryManager.UpdateInventory(position);
        Tasks.thirdtask = true;
        if (InventoryHoldingInfo.quantityOfItemsInSlots[position] == 0)
        {
            
            InventoryHoldingInfo.inventoryInfo[position] = null;
        }
       
    } 
}
