using UnityEditor.Rendering.Canvas.ShaderGraph;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraView : MonoBehaviour
{
    public GameObject player;
    public GameObject sandBorder;

    PlayerControl playerControlScript;
    [SerializeField] private Tilemap waterTilemap;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
        playerControlScript = GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Bounds mapbounds = waterTilemap.localBounds;

        var minMapX = mapbounds.min.x;
        var maxMapX = mapbounds.max.x;
        var minMapY = mapbounds.min.y;
        var maxMapY = mapbounds.max.y;

        float CameraAspect = Camera.main.aspect;

        var halfCameraSizeHeight = Camera.main.orthographicSize;
        var halfCameraSizeWidth = CameraAspect * halfCameraSizeHeight;

        float moveSpeed = playerControlScript.moveSpeed;
        var playerPos = transform.position;
        var cameraPos = Camera.main.transform.position;
        cameraPos.z = -10;
        var SafeMinX= minMapX + halfCameraSizeWidth;
        var SafeMaxX = maxMapX - halfCameraSizeWidth;
        var SafeMinY = minMapY + halfCameraSizeHeight;
        var SafeMaxY= maxMapY - halfCameraSizeHeight;

        var CameraPosX = Mathf.Clamp(playerPos.x, SafeMinX, SafeMaxX);
        var CameraPosY = Mathf.Clamp(playerPos.y, SafeMinY, SafeMaxY);
        Vector3 newCameraPos = new Vector3(CameraPosX, CameraPosY, -10);
        Camera.main.transform.position = newCameraPos;
   
 

       
       
        
    }

    //float getMoveSpeed()
    //{
    //    float moveSpeed = playerControlScript.moveSpeed;
    //        return moveSpeed;
    //}

}
