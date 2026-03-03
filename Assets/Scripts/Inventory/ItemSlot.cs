using TMPro;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
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

    private InventoryManager InventoryManager;


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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
