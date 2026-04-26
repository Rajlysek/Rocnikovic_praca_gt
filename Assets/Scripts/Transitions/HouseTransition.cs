using UnityEditor.Analytics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseTransition : MonoBehaviour
{
    
    [SerializeField] private string SceneToLoad;
    public GameObject RespawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    // Update is called once per frame
  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            PositionManager manager = collision.GetComponent<PositionManager>();
            if(manager != null)
            {
                manager.RespawnPointForPosition(RespawnPoint);
            }
            SceneManager.LoadScene(SceneToLoad);
        }
    }
   
}
