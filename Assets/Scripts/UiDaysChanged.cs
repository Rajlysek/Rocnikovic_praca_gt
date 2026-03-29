using TMPro;
using UnityEngine;

public class UiDaysChanged : MonoBehaviour
{
    [SerializeField] private DaysManagerSO daysManager;
    private TMP_Text _UIDayNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //register to subsripe, as soon as the object actives
    private void Awake()
    {
        _UIDayNumber = GetComponent<TMP_Text>();
        string numberOfTheDay = daysManager.currentDay.ToString();
        _UIDayNumber.text = numberOfTheDay;
        _UIDayNumber.enabled = true;
    }
    private void OnEnable()
    {
        daysManager.OnDayChange += TextChange;
    }
    private void OnDisable()
    {
        daysManager.OnDayChange -= TextChange;
    }

    private void TextChange()
    {
        
        string numberOfTheDay = daysManager.currentDay.ToString();
        _UIDayNumber.text = numberOfTheDay;
        _UIDayNumber.enabled = true;

    }
}
