using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string ItemName;
    public int quantity;
    public Sprite ItemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField]
    private int maxNumberOfItems;


    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image ItemImage;


    public Image itemDescriptionImage;
    public TMP_Text itemDescriptionNameText;
    public TMP_Text itemDescriptionText;


    private InventoryManager inventoryManager;
    
    public GameObject SelectedShader;
    public bool ThisItemHasBeenSelected;
    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        if(isFull)
        { 
            return quantity; 
        }
        //UPDATE NAME
        this.ItemName = itemName;
        
        //update Image
        this.ItemSprite = itemSprite;

        ItemImage.enabled = true;
        ItemImage.sprite = ItemSprite;

        //Update description
        this.itemDescription = itemDescription;

        //update Quantity
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems) 
        {
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            isFull = true;

            quantityText.text = maxNumberOfItems.ToString();
            quantityText.enabled = true; 
            return extraItems;
        }


        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }
    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        SelectedShader.SetActive(true);
        ThisItemHasBeenSelected = true;
        itemDescriptionNameText.text = ItemName;
        itemDescriptionText.text = itemDescription;
        itemDescriptionImage.sprite = ItemSprite;
        if(itemDescriptionImage == null)
        {
            itemDescriptionImage.sprite = emptySprite;
        }
        
    }
    public void OnRightClick() 
    {

    }

}
