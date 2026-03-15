using UnityEngine;

public class MenuMoving : MonoBehaviour
{
    [SerializeField] private Transform cameraOfPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraOfPlayer = GameObject.Find("CameraOfThePlayer").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(cameraOfPlayer.position.x, cameraOfPlayer.position.y, cameraOfPlayer.position.z);
        transform.position = newPos;
    }
}
