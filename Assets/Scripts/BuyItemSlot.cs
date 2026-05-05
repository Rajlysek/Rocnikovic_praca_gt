using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyItemSlot : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ItemName;
    [SerializeField]
    private Image ItemImage;
    [SerializeField]
    private TMP_Text Price;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetInfo(ItemSO itemInfo)
    {
        Price.text = itemInfo.price.ToString(); 
        ItemName.text = itemInfo.itemName;
        ItemImage.sprite = itemInfo.itemIcon;
    }
}
