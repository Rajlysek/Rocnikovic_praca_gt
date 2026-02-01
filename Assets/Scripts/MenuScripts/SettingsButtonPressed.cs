using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SettingsButtonPressed : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
  
   

    public GameObject normalButtonSettings;
    public GameObject pressedButtonSetting;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
      
        normalButtonSettings.SetActive(true);
        pressedButtonSetting.SetActive(false);
    }


    // Update is called once per frame
   
    void Update()
    {

        
    }
    public void OnPointerEnter(PointerEventData pointerEventData) 
    {
        Debug.Log("isTouching");

        normalButtonSettings.SetActive(false);
        pressedButtonSetting.SetActive(true);
    }
    public void OnPointerExit(PointerEventData pointerEventData) 
    {
        
        Debug.Log("isNotTouching");

        normalButtonSettings.SetActive(true);
        pressedButtonSetting.SetActive(false);
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

}
