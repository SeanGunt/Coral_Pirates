using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : Clickable
{
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private GameObject itemToAdd;
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
        InventoryItem inventoryItem = InventoryManager.instance.AddItemToInventory();
        if (inventoryItem != null)
        {
            Image image = inventoryItem.gameObject.GetComponent<Image>();
            GameObject itemToPurchase = Instantiate(itemToAdd, inventoryItem.transform);
            image.sprite = itemSprite;
            image.color = Color.white;
            Destroy(gameObject.transform.parent.gameObject);
        }
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
