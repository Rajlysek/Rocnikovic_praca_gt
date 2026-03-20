using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
    [SerializeField] private string SceneToLoad;
    [SerializeField] private GameObject respawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PositionManager manager = collision.GetComponent<PositionManager>();
            if(manager != null)
            {
                manager.RespawnPointForPosition(respawnPoint);
            }
            SceneManager.LoadScene(SceneToLoad, LoadSceneMode.Single);
        }
    }
}
