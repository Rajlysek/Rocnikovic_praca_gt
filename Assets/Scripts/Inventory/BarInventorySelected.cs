using UnityEngine;

public class BarInventorySelected : MonoBehaviour
{
    public GameObject[] SelectedSlots;
    public ActionsOfPlayer actionsOfPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actionsOfPlayer = GameObject.Find("Player").GetComponent<ActionsOfPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void WaitForButton()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DeselectAllSlots();
            SelectedSlots[0].SetActive(true);
            actionsOfPlayer.ItemID = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DeselectAllSlots();
            SelectedSlots[1].SetActive(true);
            actionsOfPlayer.ItemID = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DeselectAllSlots();
            SelectedSlots[2].SetActive(true);
            actionsOfPlayer.ItemID = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DeselectAllSlots();
            SelectedSlots[3].SetActive(true);
            actionsOfPlayer.ItemID = 4;
        }
    }
    public void DeselectAllSlots()
    {
        for (int i = 0; i < SelectedSlots.Length; i++)
        {
            SelectedSlots[i].SetActive(false);
           
        }
    }
}
