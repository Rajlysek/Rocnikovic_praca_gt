using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStatsSO : ScriptableObject
{
    public int stamina = 100;
    public int water = 100;
    public int gold = 0;
}
