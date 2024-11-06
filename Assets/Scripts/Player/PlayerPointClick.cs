using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class PlayerPointClick : MonoBehaviour, IDataGrabber
{
    private Vector2 target;
    private NavMeshAgent agent;
    private SpriteRenderer spriteRenderer;
    public GameObject inventoryGO;
    public float minScale = 0.6f;  // Minimum scale factor
    public float maxScale = 1.0f;  // Maximum scale factor
    public float scaleThreshold = 20.0f;  // Where should sprite be at max scale i made this up btw

    public Animator animator;
    int PlayerCam = 0;
    int DialogueCam = 0;

    public void LoadData(GameData data)
    {
        transform.position = data.position;
    }

    public void SaveData(GameData data)
    {
        data.position = transform.position;
    }


    private void Start()
    {
        target = transform.position;
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        animator = GetComponent<Animator>(); 
        animator.enabled = true;
        

        PlayerCam = 1;

    }

    private void Update()
    {
        HandleMouseInput();
        AdjustPerspective();
        OpenInventory();

        animator.SetInteger("PlayerCam", PlayerCam);
        animator.SetInteger("DialogueCam", DialogueCam);

    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0) && !PauseMenu.instance.GetPauseStatus() && !DialogueManager.instance.CheckIfInDialogue() && !InventoryManager.instance.currentlyHoveringItem) // 0 for left mouse button, 1 for right mouse button
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

    public void SetTarget(Vector3 targetPositionToSet)
    {
        target = targetPositionToSet;
        agent.SetDestination(new Vector3(target.x, target.y, 0f));
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


    public void LemTalking()
    {
        Debug.Log("lem talking active");
        PlayerCam = 0;
        DialogueCam = 1;
    }

    public void LemNotTalking()
    {
        Debug.Log("lem talking not active");
        PlayerCam = 1;
        DialogueCam = 0;
    }
}
