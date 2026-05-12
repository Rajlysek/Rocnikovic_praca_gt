using System.Collections;
using TMPro;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public static bool firstPlay = true;
    public static int CurrentTask;
    public DialogueLines dialogueLines;
    public GameObject TaskBar;
    public TMP_Text taskOne;
    public TMP_Text taskTwo;
    public DialogueLines[] dialogueLinesArray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (firstPlay)
        {

            CurrentTask = 0;
            TaskBar.SetActive(true);
            
            firstPlay = false;

        }
        if (CurrentTask == 0)
        {
            firstTask();
        }
        if (CurrentTask == 1)
        {
            secondTask();
        }
    }
   
    public void firstTask()
    {
        firstPlay = false;  
        taskOne.text = "Move around";
        taskTwo.text = "TIP: Press WASD to move around";
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(WaitAndPlayDialog(2f, CurrentTask));

            CurrentTask++;

        }
    }
    public void secondTask()
    {
        taskOne.text = "Open Inventory";
        taskTwo.text = "TIP: Press I to open the inventory";
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartCoroutine(WaitAndPlayDialog(3f, CurrentTask));

            CurrentTask++;
        }
    }
    private IEnumerator WaitAndPlayDialog(float delaySeconds, int taskIndexToPlay)
    {
        
        yield return new WaitForSeconds(delaySeconds);

      
        
        dialogueLinesArray[taskIndexToPlay].StartDialog();
    }
}