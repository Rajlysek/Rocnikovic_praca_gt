using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionManager : MonoBehaviour
{
    
    public static Dictionary<string, Vector3> positionInScenes = new Dictionary<string, Vector3>();
    public static Vector3 LastPlayerPosition = new Vector3();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gets name of the current scene
        string nameOfTheCurrentScene = SceneManager.GetActiveScene().name;
        //if dictionary contains name of the scene then gets player position there, otherwise create the key in dictionary
        LastPlayerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //transform.position = LastPlayerPosition;
        if (positionInScenes.ContainsKey(nameOfTheCurrentScene))
        {
            transform.position = positionInScenes[nameOfTheCurrentScene];
        }
    }
   // private void Update()
   // {
   //     string nameOfCurrentScene = SceneManager.GetActiveScene().name;
   //     LastPlayerPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
   //     positionInScenes[nameOfCurrentScene] = LastPlayerPosition;
   // }
    public void RespawnPointForPosition(GameObject RespawnPoint)
    {
        string nameOfCurrentScene = SceneManager.GetActiveScene().name;
        Vector3 RespawnPositionCoordinates = new Vector3(RespawnPoint.transform.position.x, RespawnPoint.transform.position.y, RespawnPoint.transform.position.z);
        positionInScenes[nameOfCurrentScene] = RespawnPositionCoordinates;
    }
}
