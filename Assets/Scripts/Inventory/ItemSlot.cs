using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;
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
    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        
        this.ItemName = itemName;
        this.quantity = quantity;
        this.ItemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

       
        quantityText.enabled = true;
        ItemImage.enabled = true;
        quantityText.text = quantity.ToString();
        ItemImage.sprite = ItemSprite;
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
