using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot;
    public GameObject Seeding;
    public InventoryHoldingInfo inventoryHoldingInfo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        LoadInventory();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            if (Seeding != null)
            {
                Seeding.SetActive(true);
            }

            menuActivated = false;
        }
        else if (Input.GetKeyDown(KeyCode.I) && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            if (Seeding != null)
            {
                Seeding.SetActive(false);
            }

            menuActivated = true;
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].isFull && itemSlot[i].ItemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);

                if (InventoryHoldingInfo.instance != null)
                {
                    InventoryHoldingInfo.instance.AddItemToTheDictionary(itemName, i, itemSlot[i].quantity);
                }
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);

                }
                return leftOverItems;

            }
        }
        Debug.Log(quantity);
        return quantity;

    }
    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].SelectedShader.SetActive(false);
            itemSlot[i].ThisItemHasBeenSelected = false;
        }
    }
    
    private void LoadInventory()
    {
        foreach (var item in InventoryHoldingInfo.inventoryInfo)
        {
            int slotIndex = item.Key;
            ItemSO savedItem = item.Value;
            int savedQuantity = InventoryHoldingInfo.quantityOfItemsInSlots[slotIndex];
            itemSlot[slotIndex].AddItem(savedItem.itemName, savedQuantity, savedItem.itemIcon, savedItem.Description);
        }
    }
    public void UpdateInventory(int position) 
    {
        itemSlot[position].UseItem();
        
    }
}

