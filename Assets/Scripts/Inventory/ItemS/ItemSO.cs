using UnityEngine;
using NaughtyAttributes;
[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public bool isSeedable;
    public bool isEatable;
    public bool isSellable;
    public string Description;

    [ShowIf("isSeedable")]
    public int timeToGrow;

    [ShowIf("isSellable")]
    public int price;

    
}
