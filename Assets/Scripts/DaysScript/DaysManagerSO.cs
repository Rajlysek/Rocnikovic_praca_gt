using System;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "DaysManagerSO", menuName = "Scriptable Objects/DaysManagerSO")]
public class DaysManagerSO : ScriptableObject
{
    public int currentDay = 1;

    public event Action OnDayChange;

  
    
    public void AdvanceDay()
    {
        currentDay++;

        OnDayChange?.Invoke();
    }
}
