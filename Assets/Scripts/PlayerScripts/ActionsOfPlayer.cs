using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ActionsOfPlayer : MonoBehaviour
{
    PlayerControl playerControlScript;
    private Animator _animator;
    [SerializeField] private Tilemap GrassTilemap;
    [SerializeField] private Tilemap HoeTilemap;
    [SerializeField] private TileBase hoedDirtTileAlone;
    [SerializeField] private TileBase hoedDirtTileWetAlone;
    
    private Rigidbody2D rb2;
    private bool isActing = false;
    public Vector3Int FinalTilesPosition;
    public int ItemID;
    public FarmManager farmManager;
    public GameObject seedButton;
    public Button button;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        playerControlScript = GetComponent<PlayerControl>();

        farmManager = GameObject.Find("FarmManager").GetComponent<FarmManager>();

        button = seedButton.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
       
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

        FinalTilesPosition = HoeTilemap.WorldToCell(TilePosition);
        //if (farmManager.buttonSearch(FinalTilesPosition))
        //{
        //    seedButton.SetActive(true);
        //}
        //else seedButton.SetActive(false);
        //
      



    }
    void Action() 
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
                _animator.SetTrigger("SpaceWasPressed");

                //zkontroluju zda se nachazi na míste kde muze vyrýt hlinu
                if (GrassTilemap.HasTile(isPlayerOnGrass) && GrassTilemap.HasTile(playerPositionInAction))
                {
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
                
                break;
            case 2:
                
                
                _animator.SetTrigger("SpaceWasPressed");
                if (HoeTilemap.HasTile(FinalTilesPosition))
                {
                    farmManager.WettingTheTile(FinalTilesPosition);
                    StartCoroutine(WaitForAnimation());
                    
                }
                else
                {
                    Debug.Log("Noting There");
                }
                
                break;
            case 3:
                _animator.SetTrigger("SpaceWasPressed");
                
                break;
        }
    }
    IEnumerator WaitForAnimation()
    {
        isActing = true;
        
        yield return new WaitForSeconds(0.5f);
        if (ItemID == 1) 
        { 
            HoeTilemap.SetTile(FinalTilesPosition, hoedDirtTileAlone);
        }
        else if (ItemID == 2)
        {
            HoeTilemap.SetTile(FinalTilesPosition, hoedDirtTileWetAlone);
        }
        isActing = false;

    }
    void TaskOnClick()
    {

    }
}
      
        

