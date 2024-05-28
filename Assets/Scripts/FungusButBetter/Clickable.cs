using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] private float activationDistance;
    private GameObject player;
    protected bool closeToClickable;
    private float distanceToPlayer;

    protected virtual void Start()
    {
        player = GameManager.instance.player;
    }

    protected void Update()
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

    public virtual void OnClickableClicked()
    {

    }
}
