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
    private void Awake()
    {
        instance = this;
    }

    public bool CheckIfInDialogue()
    {
        return inDialogue;
    }

    public bool SetIfInDialogue(bool areYouInDialogue)
    {
        inDialogue = areYouInDialogue;
        return inDialogue;
    }

    public void StartDialogue(List<string> dialogeToSet)
    {
        dialogueCanvas.SetActive(true);
        inDialogue = true;
        masterText.text = dialogeToSet[0];
    }

    public void EndDialogue()
    {
        dialogueCanvas.SetActive(false);
        inDialogue = false;
    }
}
