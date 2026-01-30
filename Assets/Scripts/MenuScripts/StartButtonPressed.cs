using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class StartButtonPressed : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
  
   

    public GameObject normalButton;
    public GameObject pressedButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        normalButton.SetActive(true);
        pressedButton.SetActive(false);
    }


    // Update is called once per frame
   
    void Update()
    {

        
    }
    public void OnPointerEnter(PointerEventData pointerEventData) 
    {
        Debug.Log("isTouching");
        
        normalButton.SetActive(false);
        pressedButton.SetActive(true);
    }
    public void OnPointerExit(PointerEventData pointerEventData) 
    {
        
        Debug.Log("isNotTouching");
        
        normalButton.SetActive(true);
        pressedButton.SetActive(false);
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

}
