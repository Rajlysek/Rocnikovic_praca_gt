using UnityEngine;
using UnityEngine.Rendering.Universal;
//using UnityEngine.inputSystem;

public class BedScript : MonoBehaviour
{
    bool IsInRangeofBed = false;
    static public int DaysCounter = 0;
    public DaysManagerSO dayManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (IsInRangeofBed && Input.GetKeyDown(KeyCode.Space))
        {
            dayManager.AdvanceDay();
            Debug.Log("Sleept");
        }       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            IsInRangeofBed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRangeofBed = false;
        }
    }
}
