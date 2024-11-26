using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public GameObject dialogueCanvas;
    public TextMeshProUGUI masterText;
    public TextMeshProUGUI nameText;
    public NPC currentNPC;
    public float timeBetweenCharacters;
    public bool typeWriteActive;
    int visibleCount;
    int totalVisibleCharacters;
    int counter;
    private void Awake()
    {
        instance = this;
        dialogueCanvas.SetActive(true);
    }

    public void StartDialogue(List<string> dialogueToSet, NPC npcToSet)
    {
        GameManager.instance.lemCanMove = false;
        currentNPC = npcToSet;
        nameText.text = npcToSet.characterName;
        masterText.text = dialogueToSet[0];
        StartCoroutine(TextVisible());

        GameManager.instance.player.GetComponent<PlayerPointClick>().LemTalking();
    }

    public void ContinueDialogue()
    {
        if (typeWriteActive)
        {
            counter = totalVisibleCharacters;
            return;
        }

        if (currentNPC.index + 1 < currentNPC.dialogue.Count && !typeWriteActive)
        {
            currentNPC.index++;
            masterText.text = currentNPC.dialogue[currentNPC.index];
            StartCoroutine(TextVisible());
        }
        else
        {
            Invoke("EndDialogue", 0.1f);
            GameManager.instance.player.GetComponent<PlayerPointClick>().LemNotTalking();
        }
    }

    public void EndDialogue()
    {
        GameManager.instance.lemCanMove = true;
        currentNPC.index = 0;
        currentNPC = null;
        masterText.text = "";
        nameText.text = "";
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
