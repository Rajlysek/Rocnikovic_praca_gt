using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string ItemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;
    [TextArea]
    [SerializeField]
    private string itemDescription;

    private InventoryManager inventoryManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            int leftOverItems = inventoryManager.AddItem(ItemName, quantity, sprite, itemDescription);
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
