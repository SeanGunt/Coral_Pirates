using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledger : NPC
{
    private bool ledgerFound = false;
    public override void OnClickableClicked()
    {
        foreach (var objective in QuestManager.instance.objectives)
        {
            if (objective.TryGetValue("FFPlaced", out bool ledgerAdded) && ledgerAdded && !ledgerFound)
            {
                Debug.Log("copy pasted ahahahhah");
                indexOfDialogue++;
                ledgerFound = true;
            }
        }
        if (GameManager.instance.lemCanMove)
        {
            StartCoroutine(ActivateClickable(indexOfDialogue));
        }
    }
}
