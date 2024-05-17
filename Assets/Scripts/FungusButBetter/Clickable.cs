using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public List<string> dialogue = new();
    public string characterName;
    [SerializeField] private float activationDistance;
    private GameObject player;
    private DialogueManager dialogueManager;
    private bool closeToClickable;
    private float distanceToPlayer;
    [HideInInspector] public int index = 0;

    private void Start()
    {
        player = GameManager.instance.player;
        dialogueManager = DialogueManager.instance;
    }

    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= activationDistance)
        {
            closeToClickable = true;
        }
        else
        {
            closeToClickable = false;
        }
    }

    public void OnClickableClicked()
    {
        if (!dialogueManager.CheckIfInDialogue())
        {
            StartCoroutine(ActivateClickable());
        }
    }

    private IEnumerator ActivateClickable()
    {
        while (!closeToClickable)
        {
            yield return null;
        }
        dialogueManager.StartDialogue(dialogue, this);
    }
}
