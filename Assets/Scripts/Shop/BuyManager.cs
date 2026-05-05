using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    public ItemSO[] itemSOSeedArray;
    public ItemSO PernamentSO;
    public BuyItemSlot[] BuyItemSlots;
    static public ItemSO[] BuyItems;
    static bool firstTime = true;
    
    private void Awake()
    {
        if (BuyItems == null)
        {
            BuyItems = new ItemSO[BuyItemSlots.Length];
        }
        if (firstTime)
        {
            BuyItems[0] = PernamentSO;
            changeItems();
        }
        for (int i = 0; i < BuyItems.Length; i++)
        {
            BuyItemSlots[i].GetInfo(BuyItems[i]);
        }
            
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    
    public void BuyPanelAppear()
    {
        gameObject.SetActive(true);
    }
    private void changeItems()
    {

        for (int i = 1; i < BuyItems.Length; i++)
        {
            int randomIndex = Random.Range(0, itemSOSeedArray.Length);
            ItemSO newItem = new ItemSO();
           
            BuyItems[i] = itemSOSeedArray[randomIndex];
        }
    }
}
