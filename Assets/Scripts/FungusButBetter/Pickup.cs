using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Clickable
{
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string itemName;
    protected override void Start()
    {
        base.Start();
    }

    public override void OnClickableClicked()
    {
        StartCoroutine(ActivateClickable());
    }

    private void AddToInventory()
    {
        InventoryManager.instance.AddItemToInventory(itemName, itemSprite, this.gameObject.transform.parent.gameObject);
    }

    private IEnumerator ActivateClickable()
    {
        while (!closeToClickable)
        {
            yield return null;
        }
        AddToInventory();
    }
}
