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
    private bool isWaiting = false;
    void Start()
    {
       
       
    }

    void Update()
    {
        if (firstPlay)
        {

            CurrentTask = 0;
            TaskBar.SetActive(true);
            
            firstPlay = false;

        }
        switch (CurrentTask)
        {
            case 0:
                firstTask();
                break;
            case 1:
                secondTask();
                break;
            case 2:
                thirdTask();
                break;
            default: 
                TaskBar.SetActive(false);
                break;
        }
        
    }
   
    public void firstTask()
    {
        firstPlay = false;  
        taskOne.text = "Move around";
        taskTwo.text = "TIP: Press WASD to move around";
        if(!isWaiting && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D)))
        {
            
            StartCoroutine(CompleteTaskSequence(1f, CurrentTask, 3f));

        }
    }
    public void secondTask()
    {
        taskOne.text = "Open Inventory";
        taskTwo.text = "TIP: Press I to open the inventory";
        if (!isWaiting && Input.GetKeyDown(KeyCode.I))
        {
            
            StartCoroutine(CompleteTaskSequence(1f, CurrentTask, 3f));//


        }
    }
    public void thirdTask()
    {
        taskOne.text = "Plant the seed";
        taskTwo.text = "TIP: you can use the hoe by picking it and pressing spacebar";
    }
   
    private IEnumerator CompleteTaskSequence(float waitBeforeDialog, int taskIndexToPlay, float waitBeforeNextTask)
    {
        isWaiting = true; // Zamkneme

        // 1. Čekáme před zobrazením dialogu
        yield return new WaitForSecondsRealtime(waitBeforeDialog);

        // 2. Spustíme dialog
        dialogueLinesArray[taskIndexToPlay].StartDialog();

        // 3. Čekáme určený čas, aby hráč mohl dialog vstřebat
        yield return new WaitForSecondsRealtime(waitBeforeNextTask);

        // 4. Přepneme úkol a odemkneme skript pro další akci
        CurrentTask++;
        isWaiting = false;
    }
}