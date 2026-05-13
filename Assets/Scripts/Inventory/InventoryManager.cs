using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject barUi;
    public GameObject barTilemap;
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
            if (barUi == null)
            {
                barUi.SetActive(false);
                barTilemap.SetActive(false);
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
            if (barUi == null)
            {

                barTilemap.SetActive(true);
                barUi.SetActive(true);
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
    
    public void LoadInventory()
    {
        for(int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].EmptySlot();
        }
        for(int i = 0; i < InventoryHoldingInfo.inventoryInfo.Count; i++)
        {
            ItemSO savedItem = InventoryHoldingInfo.inventoryInfo[i];
            int savedQuantity = InventoryHoldingInfo.quantityOfItemsInSlots[i];
            if (savedItem != null && InventoryHoldingInfo.quantityOfItemsInSlots[i] != 0)
            {
                itemSlot[i].AddItem(savedItem.itemName, savedQuantity, savedItem.itemIcon, savedItem.Description);
            }
            else
            {
                itemSlot[i].EmptySlot();
            }
        }
       
    }
    public void UpdateInventory(int position) 
    {
        itemSlot[position].UseItem();
        
    }
}

