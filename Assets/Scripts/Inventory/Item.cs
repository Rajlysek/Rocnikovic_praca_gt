using UnityEngine;

public class Item : MonoBehaviour
{
   

    [SerializeField]
    private int quantity;

    [SerializeField]
    private ItemSO itemSO;

    private InventoryManager inventoryManager;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemSO.itemIcon;
    }
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("colision");
            int leftOverItems = inventoryManager.AddItem(itemSO.itemName, quantity, itemSO.itemIcon, itemSO.Description);
            if(leftOverItems <= 0)
            {
                Destroy(gameObject);
            }
            else if (leftOverItems > 0)
            { 
                quantity = leftOverItems;
                
            }
           

        }
    }
}
