using System.Collections;
using System.Collections.Generic;
using TMPro;

//using System.Numerics;
using UnityEngine;

public class TelescopeGame : MonoBehaviour
{

    [SerializeField]
    private Camera telescopeCamera;
    private Vector3 dragOrigin;
    public SpriteRenderer mapBackground;
    private float mapMinX, mapMaxX, mapMinY, mapMaxY;
    private float zoomStep, minCamSize, maxCamSize;
    private float viewport = 10f;
    public Canvas telescopeCanvas;
    public int currentPieces;
    public int totalPieces;
    public TextMeshProUGUI collectedText;
    public GameObject[] findingSpots;

    private void OnEnable()
    {
        //MapBoundary();

        GameManager.instance.lemCanMove = false;
    }
    
    private void Update()
    {
        PanCamera();        
    }

    private void PanCamera()
    {
        if(Input.GetMouseButtonDown(0))
        {
        
            dragOrigin = telescopeCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, viewport));
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - telescopeCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, viewport));

            telescopeCamera.transform.position += difference;
            //telescopeCamera.transform.position = ClampCamera(telescopeCamera.transform.position + difference);
        }
    }

    private void MapBoundary()
    {
        mapMinX = mapBackground.transform.position.x - mapBackground.bounds.size.x / 2f;
        mapMaxX = mapBackground.transform.position.x + mapBackground.bounds.size.x / 2f;

        mapMinY = mapBackground.transform.position.y - mapBackground.bounds.size.y / 2f;
        mapMinY = mapBackground.transform.position.y - mapBackground.bounds.size.y /2f;
    }


    public void ZoomIn()
    {
        float newSize = telescopeCamera.orthographicSize - zoomStep;
        telescopeCamera.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        telescopeCamera.transform.position = ClampCamera(telescopeCamera.transform.position);
    }

    public void ZoomOut()
    {
        float newSize = telescopeCamera.orthographicSize + zoomStep;
        telescopeCamera.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        telescopeCamera.transform.position = ClampCamera(telescopeCamera.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = telescopeCamera.orthographicSize;
        float camWidth = telescopeCamera.orthographicSize * telescopeCamera.aspect;
        
        float minX = mapMinX + camWidth;
        float maxX = mapMaxX + camWidth;
        float minY = mapMinY - camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }

    public void ExitGame()
    {
        GameManager.instance.lemCanMove = true;

    }
    
    public void CollectPages()
    {
        currentPieces += 1;

        collectedText.text = currentPieces + "/" + totalPieces.ToString();

        if(currentPieces == totalPieces)
        {
            foreach (GameObject findingSpot in findingSpots)
            {
                findingSpot.SetActive(true);
            }
        }
    }
}
