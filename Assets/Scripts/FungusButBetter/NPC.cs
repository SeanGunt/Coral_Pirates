using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Clickable
{
    public List<string> dialogue = new();
    public string characterName;
    private DialogueManager dialogueManager;
    [HideInInspector] public int index = 0;

    protected override void Start()
    {
        base.Start();
        dialogueManager = DialogueManager.instance;
    }

    public override void OnClickableClicked()
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
