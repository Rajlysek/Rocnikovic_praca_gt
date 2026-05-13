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

        if (Input.GetKeyDown(KeyCode.Alpha1)) HandleSlotSelection(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) HandleSlotSelection(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) HandleSlotSelection(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) HandleSlotSelection(3);  
       
    }
    public void HandleSlotSelection(int slotIndex)
    {
        if (SelectedSlots[slotIndex].activeSelf)
        {
            DeselectAllSlots();
            Debug.Log("Slot 1 is already selected");

            actionsOfPlayer.ItemID = 0;
        }
        else
        {
            DeselectAllSlots();
            SelectedSlots[slotIndex].SetActive(true);
            UnselectedSlots[slotIndex].SetActive(false);

            actionsOfPlayer.ItemID = slotIndex + 1;
            Debug.Log("sELECTING 1");
        }
    }
}
