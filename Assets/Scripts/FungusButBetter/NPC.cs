using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueChecker
{
    public List<string> dialogueToUse = new();
}
public class NPC : Clickable
{
    public List<DialogueChecker> dialogue = new();
    public string characterName;
    protected DialogueManager dialogueManager;
    [HideInInspector] public int index = 0;
    [HideInInspector] public int indexOfDialogue = 0;

    protected override void Start()
    {
        base.Start();
        dialogueManager = DialogueManager.instance;
    }

    public override void OnClickableClicked()
    {
        if (GameManager.instance.lemCanMove)
        {
            StartCoroutine(ActivateClickable(indexOfDialogue));
        }
    }

    protected virtual IEnumerator ActivateClickable(int indexOfDialogue)
    {
        while (!closeToClickable)
        {
            yield return null;
        }
        dialogueManager.StartDialogue(dialogue[indexOfDialogue].dialogueToUse, this);
    }
}
