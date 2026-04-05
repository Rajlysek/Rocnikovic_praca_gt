using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SeedingScrollViewSlot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SeedingScrollView seedingScrollView;
    public SeedingManager seedingManager;
    public string ItemName;
    public Sprite ItemSprite;
    public int ItemQuantity;
    public ItemSO ItemSO;
    [SerializeField]
    private TMP_Text quantityText;
    [SerializeField]
    private Image ItemIcon;
    [SerializeField]
    private TMP_Text nameText;


    void Start()
    {
        Button buttom = GetComponent<Button>(); 
        buttom.onClick.AddListener(SeedOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetItemInfo(ItemSO itemSO, int quantity)
    {
        this.ItemSO = itemSO;
        this.ItemName = itemSO.name;
        this.ItemQuantity = quantity;
        this.ItemSprite = itemSO.itemIcon;
        ItemIcon.enabled = true;
        ItemIcon.sprite = ItemSprite;
        quantityText.text = ItemQuantity.ToString();
        quantityText.enabled = true;
        nameText.text = ItemName.ToString();
        nameText.enabled = true;



    }
    public void ClearSlot()
    {
        ItemName = "";
        ItemQuantity = 0;
        ItemSprite = null;

        ItemIcon.enabled = false;
        quantityText.enabled = false;
        nameText.enabled = false;

    }
    void SeedOnClick()
    {
        if ( ItemQuantity != 0 )
        {
            Debug.Log("seed");
            seedingScrollView.SeedOnClick(ItemSO);
            seedingManager.SeedOnTile(ItemSO);
            ClearSlot();
        }
        else Debug.Log("No seed to seed");
    }
}
