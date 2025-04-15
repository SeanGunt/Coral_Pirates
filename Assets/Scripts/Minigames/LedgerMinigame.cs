using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgerMinigame : Clickable
{
    [SerializeField] private GameObject minigameCanvas;
    public override void OnClickableClicked()
    {
        minigameCanvas.SetActive(true);
    }
}
