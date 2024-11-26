using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : Clickable, IDataGrabber
{
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private GameObject itemToAdd;
    [SerializeField] private string objectName;
    private bool itemAdded;

    public void LoadData(GameData data)
    {
        data.itemCollected.TryGetValue(objectName, out itemAdded);
        if (itemAdded)
        {
            transform.parent.gameObject.SetActive(false);
        }
        
    }

    public void SaveData(GameData data)
    {
        if(data.itemCollected.ContainsKey(objectName))
        {
            data.itemCollected.Remove(objectName);
        }
        data.itemCollected.Add(objectName, itemAdded);
    }
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
        if (inventoryItem != null && !itemAdded)
        {
            Image image = inventoryItem.gameObject.GetComponent<Image>();
            Instantiate(itemToAdd, inventoryItem.transform);
            image.sprite = itemSprite;
            image.color = Color.white;
            itemAdded = true;
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
