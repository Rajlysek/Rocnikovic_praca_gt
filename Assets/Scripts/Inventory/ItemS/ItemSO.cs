using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Tilemaps;
[CreateAssetMenu(fileName = "ItemSO", menuName = "Scriptable Objects/ItemSO")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public bool isSeedable;
    public bool isEatable;
    public bool isSellable;
    public bool isCorn;
    public string Description;
    public BoxCollider2D plantsCollider;
    public CurrentPhase currentPhase;
    public ItemSO product;
    
    [ShowIf("isSeedable")]
    public TileBase firstPhase;
    [ShowIf("isSeedable")]
    public TileBase secondPhase;
    [ShowIf("isSeedable")]
    public TileBase thirdPhase;
    [ShowIf("isSeedable")]
    public TileBase fourthPhase;

    [ShowIf("isSeedable")]
    public TileBase firstPhaseWet;
    [ShowIf("isSeedable")]
    public TileBase secondPhaseWet;
    [ShowIf("isSeedable")]
    public TileBase thirdPhaseWet;
    [ShowIf("isSeedable")]
    public TileBase fourthPhaseWet;


    [ShowIf("isSeedable")]
    public int timeToGrow;

    [ShowIf("isCorn")]  
    public TileBase fifthPhase;
     [ShowIf("isCorn")]
    public TileBase fourthPhasev2;
    [ShowIf("isCorn")]
    public TileBase fifthPhasev2;

    [ShowIf("isSellable")]
    public int price;

    public TileBase[] Phase;
    public TileBase[] WetPhase;
    
}
public enum CurrentPhase
{
    seed,
    firstPhase,
    secondPhase,
    thirdPhase,
    fourthPhase,
    fifthPhase,
    nonePhase
}
