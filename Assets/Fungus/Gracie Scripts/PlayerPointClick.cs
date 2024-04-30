using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPointClick : MonoBehaviour
{
    public Vector2 target;

    private NavMeshAgent agent;

    public float minScale = 0.6f;  // Minimum scale factor
    public float maxScale = 1.0f;  // Maximum scale factor
    public float scaleThreshold = 20.0f;  // Where should sprite be at max scale

    public bool inDialogue;

    private void Start()
    {
        target = transform.position;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if(inDialogue != true)
        {
            HandleMouseInput();

            agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
        
            AdjustPerspective();

        }
        
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0)) // 0 for left mouse button, 1 for right mouse button
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target = mousePosition;
        }
    }

    private void AdjustPerspective()
    {
        float currentYPosition = transform.position.y;

        float t = Mathf.InverseLerp(scaleThreshold, 0, currentYPosition); 
        float targetScale = Mathf.Lerp(minScale, maxScale, t);

        transform.localScale = new Vector3(targetScale, targetScale, 1);
    }

     /*private void OnCollisionStay2D(Collision2D collision)
    {
        target = transform.position;
    }*/

    public void ExitDialogue()
    {
        inDialogue = false;
    }
}
