using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : NPC
{
    private bool ffPlaced = false;
    public override void OnClickableClicked()
    {
        foreach (var objective in QuestManager.instance.objectives)
        {
            if (objective.TryGetValue("FFPlaced", out bool ffAdded) && ffAdded && !ffPlaced)
            {
                Debug.Log("Doing the thing");
                indexOfDialogue++;
                ffPlaced = true;
            }
        }
        if (GameManager.instance.lemCanMove)
        {
            StartCoroutine(ActivateClickable(indexOfDialogue));
        }
    }
}
