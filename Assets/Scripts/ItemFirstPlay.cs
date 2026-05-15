using UnityEngine;

public class ItemFirstPlay : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
       
    }
    void Start()
    {
        if (!Tasks.firstPlay)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
