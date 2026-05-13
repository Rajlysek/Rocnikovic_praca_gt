using UnityEngine;

using UnityEngine.SceneManagement;
public class Inventory : MonoBehaviour
{
    //Rigidbody2D rb;
    public GameObject barUi;
    public GameObject barTilemap;
    private bool isInventoryOpened;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        isInventoryOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.I) && !isInventoryOpened) 
        {
            isInventoryOpened = true;
            SceneManager.LoadScene("Inventory", LoadSceneMode.Additive);
            Time.timeScale = 0;
            if (barUi == null)
            {
                barUi.SetActive(false);
                barTilemap.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.I) && isInventoryOpened)
        {
            isInventoryOpened = false;
            SceneManager.UnloadSceneAsync("Inventory");
            Time.timeScale = 1;
            if(barUi == null)
            {

                barTilemap.SetActive(true);
                barUi.SetActive(true);
            }
        }
    
    }
}
