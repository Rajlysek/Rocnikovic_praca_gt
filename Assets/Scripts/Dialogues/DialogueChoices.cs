using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoices : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject dialogueTilemap;
    public Dialogue dialogue;

    public GameObject Choice1;
    public GameObject Choice2;
    public GameObject Choice3;
    public GameObject Leave;
    Button one;
    Button two;
    Button three;
    Button leave;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Choice1 != null)
        {
            one = Choice1.GetComponent<Button>();
            one.onClick.AddListener(ChoiceOne);
        }
        if (Choice2 != null)
        {
            two = Choice2.GetComponent<Button>();

        }
        if (Choice3 != null)
        {
            three = Choice3.GetComponent<Button>();

        }
        if (Leave != null)
        {
            leave = Leave.GetComponent<Button>();
            leave.onClick.AddListener(ChoiceLeave);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChoiceOne()
    {

    }
    public void ChoiceLeave()
    {
        dialogue.Erase();
    }
    public void ButtonAppear()
    {
        if (Choice1 != null)
        {

            Choice1.SetActive(true);
        }
        if (Choice2 != null)
        {
            Choice2.SetActive(true);
        }
        if (Choice3 != null)
        {
            Choice3.SetActive(true);
        }
        if (Leave != null)
        {
            Leave.SetActive(true);
        }

    }
    public void buttonDisappear()
    {
        if(Choice1 != null)
        {

            Choice1.SetActive(false);
        }
        if (Choice2 != null) 
        {
            Choice2.SetActive(false);
        }
        if (Choice3 != null) 
        { 
            Choice3.SetActive(false);
        }
        if (Leave != null)
        { 
            Leave.SetActive(false);
        }

    }
}
