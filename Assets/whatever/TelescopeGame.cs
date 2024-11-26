using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        //MapBoundary();
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

    
    /*
    
    //public bool telescopeCam = false;
    //public Texture2D telescopeCursor; //null = default system cursor
    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;
    //nooo it would need to be a gameobject attached to the cursor?

    private Vector3 scopePosition;
    private float moveSpeed = 1;

    private Canvas canvas;

    
    void Start()
    {
        GameManager.instance.player.GetComponent<PlayerPointClick>().LemTelescope();

        canvas = GetComponentInParent<Canvas>();
    }

    
    void Update()
    {
        scopePosition = Input.mousePosition;
		//scopePosition = Camera.main.ScreenToWorldPoint(scopePosition);
		//transform.position = Vector2.Lerp(transform.position, scopePosition, moveSpeed);

        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, scopePosition, canvas.worldCamera, out Vector2 position);
        transform.position = canvas.transform.TransformPoint(position);

        
    }

    public void HandleTelescopeGame()
    {
        //when minigame is active, set telescope cam to true
        //when telescope cam is true
        //change cursor
        //camera follows mouse position
        //mousePosition = Input.mousePosition;
		//mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		//transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }*/
}
