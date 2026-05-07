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
    public void GetInfoItem(ItemSO itemInfo)
    {
        thisItem = itemInfo;
        ItemName.enabled = true;
        ItemPrice.enabled = true;
        ItemImage.enabled = true;
        ItemName.text = itemInfo.itemName;
        ItemPrice.text = itemInfo.price.ToString();
        ItemImage.sprite = itemInfo.itemIcon;
    }
    public void ButtonClicked()
    {
        if (thisItem != null)
        {
            if(playerStats != null)
            {
                playerStats.money += thisItem.price;

            }
            else
            {
                Debug.LogError("Chybí reference na playerStats ve slotu!");
                return;
            }
                int position = 0;
            for (int i = 0; i < InventoryHoldingInfo.inventoryInfo.Count; i++)
            {
                if(thisItem == InventoryHoldingInfo.inventoryInfo[i])
                {
                    position = i;
                    InventoryHoldingInfo.quantityOfItemsInSlots[position] -= 1;

                    if (InventoryHoldingInfo.quantityOfItemsInSlots[position] == 0)
                    {

                        InventoryHoldingInfo.inventoryInfo[position] = null;
                        InventoryHoldingInfo.quantityOfItemsInSlots[position] = 0;
                    }
                    if (inventoryManager != null) inventoryManager.UpdateInventory(position);
                    if (sellManager != null) sellManager.SellableItemsInInventory();
                    break;
                }
               
               
            }

        }
        
    }
}
