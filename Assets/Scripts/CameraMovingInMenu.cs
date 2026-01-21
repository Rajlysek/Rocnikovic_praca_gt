using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraMovingInMenu : MonoBehaviour
{
    [SerializeField] private Tilemap waterTilemap;
    public float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveSpeed = 5;
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


        var playerPos = transform.position;
        var cameraPos = Camera.main.transform.position;
        cameraPos.z = -10;
        var SafeMinX = minMapX + halfCameraSizeWidth;
        var SafeMaxX = maxMapX - halfCameraSizeWidth;
        var SafeMinY = minMapY + halfCameraSizeHeight;
        var SafeMaxY = maxMapY - halfCameraSizeHeight;

        var CameraPosX = Mathf.Clamp(cameraPos.x, SafeMinX, SafeMaxX);
        var CameraPosY = Mathf.Clamp(cameraPos.y, SafeMinY, SafeMaxY);
        Vector3 newCameraPos = new Vector3(CameraPosX, CameraPosY, -10);
        Camera.main.transform.position = newCameraPos;

    }
}
