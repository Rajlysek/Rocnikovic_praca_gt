using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] ItemSlot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && menuActivated)
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false; 
        }
        else if (Input.GetKeyDown(KeyCode.I) && !menuActivated)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription) 
    {
       
        for (int i = 0; i < ItemSlot.Length; i++) 
        {
            if (!ItemSlot[i].isFull && ItemSlot[i].ItemName == itemName || ItemSlot[i].quantity == 0) 
            { 
                int leftOverItems = ItemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if(leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                    
                }
                return leftOverItems;
                
            }
        }
        return quantity;

    } 
    public void DeselectAllSlots()
    {
        for (int i = 0; i < ItemSlot.Length; i++)
        {
            ItemSlot[i].SelectedShader.SetActive(false);
            ItemSlot[i].ThisItemHasBeenSelected = false;
        }
    }
    
}
