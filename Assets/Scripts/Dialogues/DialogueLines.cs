    using UnityEngine;
    using UnityEngine.UI;

    public class DialogueLines : MonoBehaviour
    {
        [SerializeField]
        private string[] lines;
        [SerializeField]
        private bool[] playerTalking;
        [SerializeField]
        private bool[] isChoice;
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
            if (isIn && Input.GetKeyDown(KeyCode.F) && !isInDialogue)//DialogueChoices.CanInteract)
            {
                isInDialogue = true;
                Time.timeScale = 0;
                DialogueBox.StartDialogue(this.lines, this.playerTalking, this.isChoice);
            
            }

        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("is in");
            isIn = true;
        }//
    
        private void OnTriggerExit2D(Collider2D collision)
        {
            isInDialogue = false;//
            isIn = false;
        }
        public void StartDialog()
        {
            isInDialogue = true;
            Time.timeScale = 0;///
            DialogueBox.StartDialogue(lines, playerTalking, isChoice);
        }
    }
