using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maren : NPC
{
    private bool ledgerPiecesFound = false;
    public override void OnClickableClicked()
    {
        foreach (var objective in QuestManager.instance.objectives)
        {
            if (objective.TryGetValue("LedgerPiecesFound", out bool ledgerPiecesAdded) && ledgerPiecesAdded && !ledgerPiecesFound)
            {
                Debug.Log("Doing the thing");
                indexOfDialogue++;
                ledgerPiecesFound = true;
            }
        }
        if (GameManager.instance.lemCanMove)
        {
            StartCoroutine(ActivateClickable(indexOfDialogue));
        }
    }
}
