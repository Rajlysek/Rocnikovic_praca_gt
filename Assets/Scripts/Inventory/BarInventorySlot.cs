using UnityEngine;

public class BarInventorySlot : MonoBehaviour
{
    
    private BarInventory barInventory;
    private BarInventorySelected barInventorySelected;
    private BarInventoryUnselected barInventoryUnselected;  
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        barInventory = GameObject.Find("BarInventory").GetComponent<BarInventory>();
        barInventorySelected = GameObject.Find("SelectedSlots").GetComponent<BarInventorySelected>();
        barInventoryUnselected = GameObject.Find("UnselectedSlots").GetComponent<BarInventoryUnselected>();
        barInventory.DeselectAllSlots();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKeyDown) 
        //{
        //    barInventory.WaitForButton();
            
        //}
       
    }
}
