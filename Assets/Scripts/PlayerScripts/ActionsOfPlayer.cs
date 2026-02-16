using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ActionsOfPlayer : MonoBehaviour
{
    PlayerControl playerControlScript;
    private Animator _animator;
    [SerializeField] private Tilemap GrassTilemap;
    [SerializeField] private Tilemap HoeTilemap;
    [SerializeField] private TileBase hoedDirtTileAlone;
    [SerializeField] private TileBase hoedDirtTileDownCorner;
    [SerializeField] private TileBase hoedDirtTileUpCorner;
    [SerializeField] private TileBase hoedDirtTileLeftCorner;
    [SerializeField] private TileBase hoedDirtTileRightCorner;
    [SerializeField] private TileBase hoedDirtTileGoingUp;
    [SerializeField] private TileBase hoedDirtTileGoingSide;
    private Rigidbody2D rb2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        playerControlScript = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        //zkrontroluju zda hráè zmáèknul mezernik pro akci a nehýbe se 
        if (Input.GetKeyDown("space") && _animator.GetBool("isMoving") == false && _animator.GetBool("isRunning") == false) 
        {
            //vezmu souradnice hrace a ze skriptu playerControl posledni direction hrace
            Vector2 playerPosition = transform.position;
            Vector2 LastDir = playerControlScript.lastDirection;

            //sectu je at dostanu vedlejší tile
            Vector3 TilePosition = playerPosition + LastDir;
            
            //prevedu na Vector3Int protoze tilemapy prijimaji jen Vector3Int

            Vector3Int FinalTilesPosition = HoeTilemap.WorldToCell(TilePosition);
            Vector3Int isPlayerOnGrass = GrassTilemap.WorldToCell(TilePosition);
            Vector3Int playerPositionInAction = GrassTilemap.WorldToCell(playerPosition);
            
            _animator.SetTrigger("SpaceWasPressed");
            
            _animator.SetInteger("ItemID", 1);
            //zkontroluju zda se nachazi na míste kde muze vyrýt hlinu
            if (GrassTilemap.HasTile(isPlayerOnGrass) && GrassTilemap.HasTile(playerPositionInAction)) 
            {
                HoeTilemap.SetTileFlags(FinalTilesPosition, TileFlags.None);

                HoeTilemap.SetTile(FinalTilesPosition, hoedDirtTileAlone);
            }
            else 
            {
                Debug.Log("Noting");
            }
        }
    }
    void MakingHoedPath()
    {

    }

}
