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


    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image ItemImage;

    private InventoryManager inventoryManager;
    private InventoryManager InventoryManager;
    public GameObject SelectedShader;
    public bool ThisItemHasBeenSelected;
    private void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }
    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        
        this.ItemName = itemName;
        this.quantity = quantity;
        this.ItemSprite = itemSprite;
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
        
    }
    public void OnRightClick() 
    {

    }

}
