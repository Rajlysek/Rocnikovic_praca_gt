using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class CameraMovingInMenu : MonoBehaviour
{
    [SerializeField] private Tilemap waterTilemap;
    public float moveSpeed;
    public Transform PointsForCamera;
    private Transform[] CameraPoints;
    private int point = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        moveSpeed = 5;
        Transform start = PointsForCamera.Find("Start");
        Transform first = PointsForCamera.Find("First");
        Transform second = PointsForCamera.Find("Second");
        Transform third = PointsForCamera.Find("Third");
        CameraPoints = new Transform[] { start, first, second, third };
        transform.position = CameraPoints[0].position;
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

        var cameraPos = Camera.main.transform.position;
        cameraPos.z = -10;
        var SafeMinX = minMapX + halfCameraSizeWidth;
        var SafeMaxX = maxMapX - halfCameraSizeWidth;
        var SafeMinY = minMapY + halfCameraSizeHeight;
        var SafeMaxY = maxMapY - halfCameraSizeHeight;
        
       
        if (point == 4)
        {
            point = 0;
        }
      
        var CameraPoint = CameraPoints[point];
        //ohranièení aby camera nevyjela z mapy
        var CameraPosX = Mathf.Clamp(CameraPoint.position.x, SafeMinX, SafeMaxX);
        var CameraPosY = Mathf.Clamp(CameraPoint.position.y, SafeMinY, SafeMaxY);
        
        // vytvoøeni cíle
        Vector3 TargetedPoint = new Vector3(CameraPosX, CameraPosY, -10);
        
        //posunutí k cíli za movespeed rychlost
        Camera.main.transform.position = Vector3.MoveTowards(cameraPos, TargetedPoint, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(Camera.main.transform.position, TargetedPoint) < 0.00001f)
        {
            point += 1;
        }





    }
}
