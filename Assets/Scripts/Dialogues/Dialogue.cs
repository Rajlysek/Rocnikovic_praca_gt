using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image imageComponent;
    
    public float textSpeed;
    public bool[] isPlayerTalking;
    private int index;
    private int talkingIndex;
    public DialogueChoices dialogueChoices;
    public string[] lines;
    public bool[] isChoice;
    public Sprite[] otherPersonTalking;
    public Sprite[] playerTalking;
    public Sprite nonTalkingPlayer;
    public GameObject bar;
    public GameObject tilemapOfDialogue;
    bool isChoosable = false;

 
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        gameObject.SetActive(false);
      
       
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue(string[] Objectslines, bool[] playerTalking, bool[] choice)
    {

        StopAllCoroutines();
        imageComponent.sprite = nonTalkingPlayer;
        textComponent.text = string.Empty;
        lines = Objectslines;
        isPlayerTalking = playerTalking;
        isChoice = choice;
        gameObject.SetActive(true);
        index = 0;
        talkingIndex = 0;
        if (bar != null)
        {
            bar.SetActive(false);
        }
        tilemapOfDialogue.SetActive(true);
        
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            if(talkingIndex >= playerTalking.Length)
            {
                talkingIndex = 0;
            }
            textComponent.text += c;
            if (isPlayerTalking[index])
            {
                imageComponent.sprite = playerTalking[talkingIndex];
            }
            else
            {
                imageComponent.sprite = null;
            }
                talkingIndex++;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
      
    }

    void NextLine()
    {
        if (index < isChoice.Length && isChoice[index])
        {
            
                isChoosable = true;
                dialogueChoices.ButtonAppear();
                return;
            

        }
        if (index < lines.Length - 1 && !isChoosable)
        {
            index++;
            imageComponent.sprite = nonTalkingPlayer;
            textComponent.text = string.Empty;  
            StartCoroutine(TypeLine());
        }
        else if (!isChoosable)
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            textComponent.text = string.Empty;
            imageComponent.sprite = nonTalkingPlayer;
            if(bar != null)
            {
                bar.SetActive(true);
            }
            tilemapOfDialogue.SetActive(false);
        }
    }
    public void Erase()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        textComponent.text = string.Empty;
        imageComponent.sprite = nonTalkingPlayer;
        if (bar != null)
        {
            bar.SetActive(true);
        }
        tilemapOfDialogue.SetActive(false);
        dialogueChoices.buttonDisappear();
    }
}