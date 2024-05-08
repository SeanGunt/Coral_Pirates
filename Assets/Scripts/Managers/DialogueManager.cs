using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private bool inDialogue;
    public GameObject dialogueCanvas;
    public TextMeshProUGUI masterText;
    public Clickable currentClickable;
    private void Awake()
    {
        instance = this;
    }

    public bool CheckIfInDialogue()
    {
        return inDialogue;
    }

    public void StartDialogue(List<string> dialogueToSet, Clickable clickableToSet)
    {
        dialogueCanvas.SetActive(true);
        inDialogue = true;
        currentClickable = clickableToSet;
        masterText.text = dialogueToSet[0];
    }

    public void ContinueDialogue()
    {
        if (currentClickable.index + 1 < currentClickable.dialogue.Count)
        {
            currentClickable.index++;
            masterText.text = currentClickable.dialogue[currentClickable.index];
        }
        else
        {
            Invoke("EndDialogue", 0.1f);
        }
    }

    public void EndDialogue()
    {
        dialogueCanvas.SetActive(false);
        inDialogue = false;
        currentClickable.index = 0;
        currentClickable = null;
    }
}
