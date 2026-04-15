using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;
using System;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public Image imageComponent;
    
    public float textSpeed;

    private int index;
    private int talkingIndex;
    public string[] lines;
    public Sprite[] playerTalking;
    public Sprite nonTalkingPlayer;
    public GameObject bar;
    public GameObject tilemapOfDialogue;

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

    public void StartDialogue(string[] Objectslines)
    {
      
        StopAllCoroutines();
        imageComponent.sprite = nonTalkingPlayer;
        textComponent.text = string.Empty;
        lines = Objectslines;
        gameObject.SetActive(true);
        index = 0;
        talkingIndex = 0;
        bar.SetActive(false);
        tilemapOfDialogue.SetActive(true);
        
        StartCoroutine(TypeLine());

    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            if(talkingIndex == 8)
            {
                talkingIndex = 0;
            }
            textComponent.text += c;
            imageComponent.sprite = playerTalking[talkingIndex];
            talkingIndex++;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
      
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            imageComponent.sprite = nonTalkingPlayer;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            textComponent.text = string.Empty;
            imageComponent.sprite = nonTalkingPlayer;
            bar.SetActive(true);
            tilemapOfDialogue.SetActive(false);
        }
    }
}