using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BarInventory : MonoBehaviour
{

    
    public GameObject[] SelectedSlots;
    public GameObject[] UnselectedSlots;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void DeselectAllSlots()
    {
        for (int i = 0; i < SelectedSlots.Length; i++)
        {
            SelectedSlots[i].SetActive(false);
            UnselectedSlots[i].SetActive(true);
        }
    }
    public void WaitForButton()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
            SelectedSlots[0].SetActive(true);
            UnselectedSlots[0].SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           
            SelectedSlots[1].SetActive(true);
            UnselectedSlots[1].SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
          
            SelectedSlots[2].SetActive(true);
            UnselectedSlots[2].SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
       
            SelectedSlots[3].SetActive(true);
            UnselectedSlots[3].SetActive(false);
        }
    }
}
