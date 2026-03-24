using UnityEngine;
//using UnityEngine.inputSystem;

public class BedScript : MonoBehaviour
{
    static public int DaysCounter = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ontriggerenter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") //&& Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("touching");
        }
    }
}
