using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
//using UnityEngine.inputSystem;

public class BedScript : MonoBehaviour
{
    bool IsInRangeofBed = false;
    static public int DaysCounter = 0;
    public DaysManagerSO dayManager;
    public GameObject sleepPopUp;
    public Button yesButton;
    public Button noButton;
    public PlayerControl playerControl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

      
        yesButton.onClick.AddListener(onclickYes);
        noButton.onClick.AddListener(onclickNo);

    }

    // Update is called once per frame
    void Update()
    {
        
      
        if (IsInRangeofBed && Input.GetKeyDown(KeyCode.Space))
        {
            sleepPopUp.SetActive(true);
            //dayManager.AdvanceDay();
            //Debug.Log("Sleept");
        }
        else if (!IsInRangeofBed)
        {
            sleepPopUp.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            IsInRangeofBed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsInRangeofBed = false;
        }
    }
    public void onclickYes()
    {
        sleepPopUp.SetActive(false);
        dayManager.AdvanceDay();
        Debug.Log("Sleept");
    }
    public void onclickNo()
    {
        sleepPopUp.SetActive(false);
        
        
    }
}
