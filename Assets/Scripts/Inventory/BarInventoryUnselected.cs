using UnityEngine;

public class BarInventoryUnselected : MonoBehaviour
{
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
        for (int i = 0; i < UnselectedSlots.Length; i++)
        {
            UnselectedSlots[i].SetActive(true);

        }
    }
    public void WaitForButton()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DeselectAllSlots();
            UnselectedSlots[0].SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DeselectAllSlots();
            UnselectedSlots[1].SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DeselectAllSlots();
            UnselectedSlots[2].SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DeselectAllSlots();
            UnselectedSlots[3].SetActive(false);
        }
    }
}
