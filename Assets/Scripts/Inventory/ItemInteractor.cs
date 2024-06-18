using UnityEngine;
public class ItemInteractor : MonoBehaviour
{
    public float activationDistance;
    private float distanceToPlayer;
    public bool closeToClickable;
    private GameObject player;
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
    public virtual void Interact()
    {

    }
}
