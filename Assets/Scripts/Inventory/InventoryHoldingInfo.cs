using System.Collections.Generic;
using UnityEngine;

public class InventoryHoldingInfo : MonoBehaviour
{
    static public Dictionary<int, ItemSO> inventoryInfo = new Dictionary<int, ItemSO>();
    static public Dictionary<int, int> quantityOfItemsInSlots  = new Dictionary<int, int>();
    public static InventoryHoldingInfo instance;
    public ItemSO[] itemSOs;
    public InventoryManager inventoryManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        if (instance != null)
        {
            
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }



    }
    // když se pøida item, musim ho pridat do slovniku
    //s ním i quantitu
    //takže vytvoøit metodu ktera se zavola z metody additem
    void Update()
    {
        
    }
    public void AddItemToTheDictionary(string itemName, int position, int quantity)
    {
        for(int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                if (!inventoryInfo.ContainsKey(position))
                {
                    inventoryInfo.Add(position, itemSOs[i]);
                    quantityOfItemsInSlots.Add(position, quantity);
                }
                else
                {

                }

                    return;
            }
        }
    }
}
