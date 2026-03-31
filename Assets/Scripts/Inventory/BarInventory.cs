using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BarInventory : MonoBehaviour
{

    
    public GameObject[] SelectedSlots;
    public GameObject[] UnselectedSlots;
    public ActionsOfPlayer actionsOfPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < SelectedSlots.Length; i++)
        {
            UnselectedSlots[i].SetActive(true);
            
        }
        DeselectAllSlots();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            WaitForButton();

        }
       
    }
    public void DeselectAllSlots()
    {
        for (int i = 0; i < SelectedSlots.Length; i++)
        {
            UnselectedSlots[i].SetActive(true);
            SelectedSlots[i].SetActive(false);
        }
    }
    public void WaitForButton()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1))   
        {
           
            if (SelectedSlots[0].activeSelf)
            {
                DeselectAllSlots();
                Debug.Log("Slot 1 is already selected");
                
                actionsOfPlayer.ItemID = 0;
            }
            else
            {
                DeselectAllSlots();
                SelectedSlots[0].SetActive(true);
                
                actionsOfPlayer.ItemID = 1;
                Debug.Log("sELECTING 1");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            

            if (SelectedSlots[1].activeSelf)
            {
                DeselectAllSlots();
                Debug.Log("Slot 2 is already selected");
                
                
                actionsOfPlayer.ItemID = 0;

            }
            else
            {
                DeselectAllSlots();
                Debug.Log("sELECTING 2");

                SelectedSlots[1].SetActive(true);
                
                actionsOfPlayer.ItemID = 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
           

            if (SelectedSlots[2].activeSelf)
            {
                DeselectAllSlots();
                Debug.Log("Slot 3 is already selected");
                
               
                actionsOfPlayer.ItemID = 0;


            }
            else
            {
                Debug.Log("sELECTING 3");
                DeselectAllSlots();
                SelectedSlots[2].SetActive(true);
                
                actionsOfPlayer.ItemID = 3;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
           

            if (SelectedSlots[3].activeSelf)
            {
                DeselectAllSlots();
                Debug.Log("Slot 4 is already selected");

           
                
                actionsOfPlayer.ItemID = 0;


            }
            else
            {
                DeselectAllSlots();
                Debug.Log("sELECTING 4");
                SelectedSlots[3].SetActive(true);
                
                actionsOfPlayer.ItemID = 4;
            }
        }
    }
}
