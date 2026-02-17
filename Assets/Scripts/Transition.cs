using UnityEngine;
using UnityEngine.SceneManagement;
public class Transition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void oncollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene("MiddleIsland", LoadSceneMode.Single);
            Debug.Log("Transition");
        }
    }
}