using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField]
    private string[] lines;
    public Dialogue DialogueBox;
    private bool isIn;
    private bool isInDialogue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isIn && Input.GetKeyDown(KeyCode.F) && !isInDialogue)
        {
            isInDialogue = true;
            Time.timeScale = 0;
            DialogueBox.StartDialogue(this.lines);
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("is in");
        isIn = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isInDialogue = false;
        isIn = false;
    }
}
