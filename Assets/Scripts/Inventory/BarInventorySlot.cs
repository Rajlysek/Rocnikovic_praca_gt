using UnityEngine;

public class BarInventorySlot : MonoBehaviour
{
   
  
    private BarInventorySelected barInventorySelected;
    private BarInventoryUnselected barInventoryUnselected;  
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        barInventorySelected = GameObject.Find("SelectedSlots").GetComponent<BarInventorySelected>();
        barInventoryUnselected = GameObject.Find("UnselectedSlots").GetComponent<BarInventoryUnselected>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) 
        {
            barInventorySelected.WaitForButton();
            barInventoryUnselected.WaitForButton();
        }
       
    }
}
