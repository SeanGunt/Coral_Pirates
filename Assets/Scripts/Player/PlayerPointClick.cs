using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPointClick : MonoBehaviour
{
    private Vector2 target;
    private NavMeshAgent agent;
    private SpriteRenderer spriteRenderer;
    private Clickable currentClickable;
    public GameObject inventoryGO;
    public float minScale = 0.6f;  // Minimum scale factor
    public float maxScale = 1.0f;  // Maximum scale factor
    public float scaleThreshold = 20.0f;  // Where should sprite be at max scale

    private void Start()
    {
        target = transform.position;
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        HandleMouseInput();
        AdjustPerspective();
        OpenInventory();
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && !PauseMenu.instance.GetPauseStatus() && !DialogueManager.instance.CheckIfInDialogue()) // 0 for left mouse button, 1 for right mouse button
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target = new Vector3(mousePosition.x, mousePosition.y, 0f);
            agent.SetDestination(new Vector3(target.x, target.y, 0f));
            HandleSpriteFlip();
        }
        else if (Input.GetMouseButtonDown(0) && !PauseMenu.instance.GetPauseStatus() && DialogueManager.instance.CheckIfInDialogue())
        {
            DialogueManager.instance.ContinueDialogue();
        }
    }
    

    private void AdjustPerspective()
    {
        float currentYPosition = transform.position.y;
        float t = Mathf.InverseLerp(scaleThreshold, -10, currentYPosition); 
        float targetScale = Mathf.Lerp(minScale, maxScale, t);
        transform.localScale = new Vector3(targetScale, targetScale, 1);
    }

    private void HandleSpriteFlip()
    {
        if (target.x < transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
    }

    public void WarpPlayer(Vector3 newPosition)
    {
        agent.Warp(newPosition);
        target = transform.position;
    }

    private void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryGO.activeInHierarchy)
            {
                inventoryGO.SetActive(true);
            }
            else
            {
                inventoryGO.SetActive(false);
            }
        }
    }
}
