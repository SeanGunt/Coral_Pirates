using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public List<string> dialogue = new List<string>();
    [SerializeField] private float activationDistance;
    private GameObject player;
    private bool closeToClickable;
    private float distanceToPlayer;

    private void Start()
    {
        player = GameManager.instance.player;
    }

    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= activationDistance)
        {
            closeToClickable = true;
        }
        else
        {
            closeToClickable = false;
        }
    }

    public void OnClickableClicked()
    {
        StartCoroutine(ActivateClickable());
    }

    private IEnumerator ActivateClickable()
    {
        while (!closeToClickable)
        {
            yield return null;
        }
        Debug.Log("Clickable Reached");
    }
}
