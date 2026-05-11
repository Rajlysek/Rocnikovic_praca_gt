using UnityEngine;

public class WateringCanRefill : MonoBehaviour
{
    public ActionsOfPlayer actionsOfPlayer;
   
    private Animator _animator;
    public bool isInWell = false;
    public WaterManager waterManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isInWell && Input.GetKeyDown(KeyCode.Space) && actionsOfPlayer.ItemID == 2)
        {
            waterManager.WaterReplenish();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isInWell = true;
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInWell = false;
    }
}
