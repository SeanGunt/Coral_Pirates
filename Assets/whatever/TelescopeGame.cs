using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class TelescopeGame : MonoBehaviour
{

    [SerializeField]
    private Camera telescopeCamera;
    private Vector3 dragOrigin;

    private float zoomFactor = 10f;

    private void Start()
    {
        
    }
    
    private void Update()
    {
        PanCamera();


    

    }


    private void PanCamera()
    {
        if(Input.GetMouseButtonDown(0))
        {
        
            dragOrigin = telescopeCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, zoomFactor));
        }

        if(Input.GetMouseButton(0))
            {
                Vector3 difference = dragOrigin - telescopeCamera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, zoomFactor));

                telescopeCamera.transform.position += difference;
            }
    }

    private void MoveScope()
    {

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
