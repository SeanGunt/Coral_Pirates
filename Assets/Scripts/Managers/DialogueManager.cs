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

    public bool CheckIfInDialogue()
    {
        return inDialogue;
    }

    public bool SetIfInDialogue(bool areYouInDialogue)
    {
        inDialogue = areYouInDialogue;
        return inDialogue;
    }
}
