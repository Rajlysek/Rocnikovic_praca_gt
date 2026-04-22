using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Button resumeButton;
    public Button quitButton;
    public GameObject menuPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resumeButton.onClick.AddListener(ResumePressed);
        quitButton.onClick.AddListener(QuitPressed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    void ResumePressed()
    {
        Time.timeScale = 1;

        menuPanel.SetActive(false);
    }
    void QuitPressed()
    {
        Application.Quit();
    }
}
