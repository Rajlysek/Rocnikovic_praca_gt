using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellItemSlot : MonoBehaviour
{
    [SerializeField]
    private TMP_Text ItemName;
    [SerializeField]
    private TMP_Text ItemPrice;
    [SerializeField]
    private Image ItemImage;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetInfoItem(ItemSO itemInfo)
    {
        ItemName.text = itemInfo.itemName;
        ItemPrice.text = itemInfo.price.ToString();
        ItemImage.sprite = itemInfo.itemIcon;
    }
}
