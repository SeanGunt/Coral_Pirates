using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigame : Clickable
{
    [SerializeField] private GameObject minigameCanvas;
    void PlayMinigame()
    {
        //would it be crazy if each minigame canvas or gameobj was a prefab 
        //and the specific clickable u interacted with just grabbed that prefab 
        //and u would do/complete the minigame then exit or whatever
        Instantiate(minigameCanvas, new Vector3(0, 0, 0), Quaternion.identity);
    }

    public override void OnClickableClicked()
    {
        StartCoroutine(ActivateClickable());
    }

    private IEnumerator ActivateClickable()
    {
        while (!closeToClickable)
        {
            yield return null;
        }
        PlayMinigame();
    }

    //need to disable player movement and reenable it when u exit minigame but dont want to
    //make two bools to disable lem movement

}
