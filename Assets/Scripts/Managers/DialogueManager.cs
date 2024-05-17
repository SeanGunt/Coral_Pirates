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
    public TextMeshProUGUI nameText;
    public Clickable currentClickable;
    public float timeBetweenCharacters;
    public bool typeWriteActive;
    int visibleCount;
    int totalVisibleCharacters;
    int counter;
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
        nameText.text = currentClickable.characterName;
        masterText.text = dialogueToSet[0];
        StartCoroutine(TextVisible());
    }

    public void ContinueDialogue()
    {
        if (typeWriteActive)
        {
            counter = totalVisibleCharacters;
            return;
        }

        if (currentClickable.index + 1 < currentClickable.dialogue.Count && !typeWriteActive)
        {
            currentClickable.index++;
            masterText.text = currentClickable.dialogue[currentClickable.index];
            StartCoroutine(TextVisible());
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

    private IEnumerator TextVisible()
    {
        masterText.ForceMeshUpdate();
        totalVisibleCharacters = masterText.textInfo.characterCount;
        counter = 0;
        typeWriteActive = true;

        while (true)
        {
            visibleCount = counter % (totalVisibleCharacters + 1);
            masterText.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                typeWriteActive = false;
                break;
            }

            counter += 1;
            yield return new WaitForSeconds(timeBetweenCharacters);
        }
    }
}
