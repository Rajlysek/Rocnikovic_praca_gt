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
    public BuyManager buyManager;
    private ItemSO itemInfo;
    public Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GetInfo(ItemSO itemInfo)
    {
        this.itemInfo = itemInfo;
        Price.text = itemInfo.price.ToString(); 
        ItemName.text = itemInfo.itemName;
        ItemImage.sprite = itemInfo.itemIcon;
    }
    void Start()
    {
       
        button.onClick.AddListener(() => buyManager.PlayerClicked(itemInfo));
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    
}
