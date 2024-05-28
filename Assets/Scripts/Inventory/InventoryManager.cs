using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    [SerializeField] private Transform content;
    private void Awake()
    {
        instance = this;
    }

    public void AddItemToInventory(string name, Sprite spriteToUse, GameObject objectToDestroy)
    {
        GameObject itemToAdd = new(name);
        itemToAdd.transform.SetParent(content);
        itemToAdd.transform.localPosition = Vector2.zero;
        Image image = itemToAdd.AddComponent<Image>();
        image.sprite = spriteToUse;
        Destroy(objectToDestroy);
    }
}
