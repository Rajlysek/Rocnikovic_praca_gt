using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuyManager : MonoBehaviour
{
    public ItemSO[] itemSOSeedArray;
    public ItemSO PernamentSO;
    public BuyItemSlot[] BuyItemSlots;
    static public ItemSO[] BuyItems;
    public PlayerStatsSO playerStats;
    static bool firstTime = true;
    public GameObject itemPrefab;
    public ActionsOfPlayer actionsOfPlayer;


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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
         
            BuyPanelDissapear();
        }

    }

    // Update is called once per frame
    
    public void BuyPanelAppear()
    {
        gameObject.SetActive(true);
        MenuManager.canOpenMenu = false;
    }
    public void BuyPanelDissapear()
    {
        gameObject.SetActive(false);
        MenuManager.canOpenMenu = true;
    }
    private void changeItems()
    {

        for (int i = 1; i < BuyItems.Length; i++)
        {
            int randomIndex = Random.Range(0, itemSOSeedArray.Length);               
            BuyItems[i] = itemSOSeedArray[randomIndex];
        }
    }
    public void PlayerClicked(ItemSO itembuy)
    {
        if(itembuy.price <= playerStats.money)
        {
            Vector3 playerPosition = actionsOfPlayer.playerPositionforPickup;
            playerStats.money -= itembuy.price;
            GameObject item = Instantiate(itemPrefab, actionsOfPlayer.playerPositionforPickup, Quaternion.identity);
            item.GetComponent<Item>().itemSO = itembuy;
            item.GetComponent<SpriteRenderer>().sprite = itembuy.itemIcon;
            item.GetComponent<Item>().quantity = 1;
            item.transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);


        }
    } 
}
