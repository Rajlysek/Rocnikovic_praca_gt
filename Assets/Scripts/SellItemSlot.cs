using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SellItemSlot : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ItemName;
    [SerializeField]
    private TMP_Text ItemPrice;
    [SerializeField]
    private Image ItemImage;
    Button button;
    ItemSO thisItem;
    public PlayerStatsSO playerStats;
    public InventoryManager inventoryManager;
    public SellManager sellManager;
    public int quantity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ButtonClicked);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetInfoItem(ItemSO itemInfo, int quantity)
    {
        this.quantity = quantity;
        thisItem = itemInfo;
        ItemName.enabled = true;
        ItemPrice.enabled = true;
        ItemImage.enabled = true;
        ItemName.text = itemInfo.itemName;
        ItemPrice.text = itemInfo.price.ToString();
        ItemImage.sprite = itemInfo.itemIcon;
    }
    public void DeleteItemInfo()
    {
        
        ItemName.enabled = true;
        ItemPrice.enabled = true;
        ItemImage.enabled = true;
        ItemName.text = "None";
        ItemPrice.text = "0";
        ItemImage.sprite = null;
    }
    public void ButtonClicked()
    {
        if (thisItem != null)
        {
            if(playerStats != null && ItemName.text != "None")
            {
                playerStats.money += thisItem.price;

            }
            
            
            for (int i = 0; i < InventoryHoldingInfo.inventoryInfo.Count; i++)
            {
                if(thisItem == InventoryHoldingInfo.inventoryInfo[i])
                {
                    
                    InventoryHoldingInfo.quantityOfItemsInSlots[i] -= 1;
                    quantity -= 1;

                    if (InventoryHoldingInfo.quantityOfItemsInSlots[i] == 0)
                    {

                        InventoryHoldingInfo.inventoryInfo[i] = null;
                        InventoryHoldingInfo.quantityOfItemsInSlots[i] = 0;
                        DeleteItemInfo();  
                    }
                    if (inventoryManager != null) inventoryManager.UpdateInventory(i);
                    if (sellManager != null) sellManager.SellableItemsInInventory();
                    break;
                }
               
               
            }

        }
        
    }
}
