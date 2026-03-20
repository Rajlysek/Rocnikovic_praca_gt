using UnityEngine;
using UnityEngine.Tilemaps;

public class InventoryUIScript : MonoBehaviour
{
    public GameObject InventoryGraphics;
    public GameObject UIInventoryBar;
    bool isInventoryOpen = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && !isInventoryOpen)
        {
            isInventoryOpen = true;
            InventoryGraphics.SetActive(true);
            UIInventoryBar.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.I) && isInventoryOpen)
        {
            isInventoryOpen = false;
            InventoryGraphics.SetActive(false);
            UIInventoryBar.SetActive(true);
        }
    }
}
