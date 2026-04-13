using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ActionsOfPlayer : MonoBehaviour
{
    PlayerControl playerControlScript;
    private Animator _animator;
    public StaminaManager staminaManager;
    [SerializeField] private Tilemap GrassTilemap;
    [SerializeField] private Tilemap HoeTilemap;
    [SerializeField] private TileBase hoedDirtTileAlone;
    [SerializeField] private TileBase hoedDirtTileWetAlone;
    [SerializeField] private TileBase hoedDirtTileAloneSeed;
    [SerializeField] private TileBase hoedDirtTileWetAloneSeed;
    [SerializeField] private TileBase plants;
    [SerializeField] private Tilemap plantsTilemap;

    private Rigidbody2D rb2;
    private bool isActing = false;
    public Vector3Int FinalTilesPosition;
    public int ItemID;
    public FarmManager farmManager;
    public GameObject seedButton;
    public Button button;

    public PlayerStatsSO playerStats;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        playerControlScript = GetComponent<PlayerControl>();
        if (HoeTilemap != null)
        {
            farmManager = GameObject.Find("FarmManager").GetComponent<FarmManager>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetInteger("ItemID", ItemID);
        //pokud u hrace probiha animace/akce, nedelej nic
        if (isActing) return;

        //zkrontroluju zda hráè zmáèknul mezernik pro akci a nehýbe se 
        if (Input.GetKeyDown("space") && _animator.GetBool("isMoving") == false && _animator.GetBool("isRunning") == false) 
        {
            Action();
        }
        Vector2 playerPosition = transform.position;
        Vector2 LastDir = playerControlScript.lastDirection;

        //sectu je at dostanu vedlejší tile
        Vector3 TilePosition = playerPosition + LastDir;

        //prevedu na Vector3Int protoze tilemapy prijimaji jen Vector3Int
        if (HoeTilemap != null)
        {
            FinalTilesPosition = HoeTilemap.WorldToCell(TilePosition);
        }

      



    }
    void Action() 
    {
        if (HoeTilemap != null)
        {
            //vezmu souradnice hrace a ze skriptu playerControl posledni direction hrace
            Vector2 playerPosition = transform.position;
            Vector2 LastDir = playerControlScript.lastDirection;

            //sectu je at dostanu vedlejší tile
            Vector3 TilePosition = playerPosition + LastDir;

            //prevedu na Vector3Int protoze tilemapy prijimaji jen Vector3Int

            FinalTilesPosition = HoeTilemap.WorldToCell(TilePosition);
            Vector3Int isPlayerOnGrass = GrassTilemap.WorldToCell(TilePosition);
            Vector3Int playerPositionInAction = GrassTilemap.WorldToCell(playerPosition);
            switch (ItemID)
            {

                case 1:

                    if (playerStats.stamina != 0)
                    {
                        //zkontroluju zda se nachazi na míste kde muze vyrýt hlinu
                        
                        
                        if (GrassTilemap.HasTile(isPlayerOnGrass) && GrassTilemap.HasTile(playerPositionInAction))
                        {
                            _animator.SetTrigger("SpaceWasPressed");
                            if (!HoeTilemap.HasTile(FinalTilesPosition))
                            {
                                farmManager.AddTileData(FinalTilesPosition);
                                HoeTilemap.SetTileFlags(FinalTilesPosition, TileFlags.None);
                                StartCoroutine(WaitForAnimation());
                            }

                        }
                        else
                        {
                            
                            Debug.Log("Noting");
                            
                        }

                    }
                    else Debug.Log("nostamina");

                        break;
                case 2:
                    if (playerStats.stamina != 0)
                    {
                        
                        _animator.SetTrigger("SpaceWasPressed");
                        if (HoeTilemap.HasTile(FinalTilesPosition))
                        {
                            farmManager.WettingTheTile(FinalTilesPosition);
                            StartCoroutine(WaitForAnimation());

                        }
                        else
                        {
                            staminaManager.StaminaUsed(5);
                            Debug.Log("Noting There");
                        }

                    }
                    else Debug.Log("No Stamina");

                    break;
                case 3:
                    _animator.SetTrigger("SpaceWasPressed");

                    break;
            }
        }
    }
    IEnumerator WaitForAnimation()
    {
        isActing = true;
       
        yield return new WaitForSeconds(0.5f);
        if (ItemID == 1) 
        {
            
            HoeTilemap.SetTile(FinalTilesPosition, hoedDirtTileAlone);
            farmManager.AddTileSprite(FinalTilesPosition, hoedDirtTileAlone);
            staminaManager.StaminaUsed(5);

        }
        else if (ItemID == 2)
        {
            staminaManager.StaminaUsed(5);
            if (FarmManager.farmedTiles.ContainsKey(FinalTilesPosition) &&  FarmManager.farmedTiles[FinalTilesPosition].hasSeed) 
            {
               
                var currentPhase = FarmManager.farmedTiles[FinalTilesPosition].seedCurrentPhase;
               
                if (currentPhase > CurrentPhase.seed)
                {
                    
                    int currentPhaseIndex = (int)FarmManager.farmedTiles[FinalTilesPosition].seedCurrentPhase;
                    // minus one because index of seed is 0, but in the array the zero isnt for seed but firstPhase;
                    var tileDataSprite = FarmManager.farmedTiles[FinalTilesPosition].plantedSeed.WetPhase[currentPhaseIndex-1];
                    HoeTilemap.SetTile(FinalTilesPosition, tileDataSprite);
                    farmManager.AddTileSprite(FinalTilesPosition, tileDataSprite);
                    FarmManager.farmedTiles[FinalTilesPosition].isWet = true;
                    FarmManager.farmedTiles[FinalTilesPosition].notWetFor = 0;
                }
               
                else
                {
                    HoeTilemap.SetTile(FinalTilesPosition, hoedDirtTileWetAloneSeed);
                    farmManager.AddTileSprite(FinalTilesPosition, hoedDirtTileWetAloneSeed);
                    FarmManager.farmedTiles[FinalTilesPosition].isWet = true;
                    FarmManager.farmedTiles[FinalTilesPosition].notWetFor = 0;
                }
            }
            else
            {
                HoeTilemap.SetTile(FinalTilesPosition, hoedDirtTileWetAlone);
                farmManager.AddTileSprite(FinalTilesPosition, hoedDirtTileWetAlone);
                FarmManager.farmedTiles[FinalTilesPosition].isWet = true;
                FarmManager.farmedTiles[FinalTilesPosition].notWetFor = 0;

            }
        }
        isActing = false;

    }
    public void Seeding()
    {
        if (FarmManager.farmedTiles.ContainsKey(FinalTilesPosition) && !FarmManager.farmedTiles[FinalTilesPosition].isWet)
        {
            HoeTilemap.SetTile(FinalTilesPosition, hoedDirtTileAloneSeed);
            farmManager.AddTileSprite(FinalTilesPosition, hoedDirtTileAloneSeed);

        }
        else if(FarmManager.farmedTiles.ContainsKey(FinalTilesPosition) && FarmManager.farmedTiles[FinalTilesPosition].isWet)
        {
            HoeTilemap.SetTile(FinalTilesPosition, hoedDirtTileWetAloneSeed);
            farmManager.AddTileSprite(FinalTilesPosition, hoedDirtTileWetAloneSeed);
        }
    }
    void TaskOnClick()
    {

    }
}
      
        

