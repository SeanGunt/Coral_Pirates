using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    [SerializeField] private MouseFollower mouseFollower;
    [SerializeField] private GameObject ghostImagePrefab;
    private GameObject ghostImage;
    private bool currentlyDraggingItem;
    [HideInInspector] public bool currentlyHoveringItem = false;
    public List<InventoryItem> inventoryList = new(24);
    private void Awake()
    {
        instance = this;
        foreach (InventoryItem inventoryItem in inventoryList)
        {
            InitializeUIHandling(inventoryItem);
        }
    }

    public void InitializeUIHandling(InventoryItem inventoryItem)
    {
        inventoryItem.OnItemClicked += HandleItemSelection;
        inventoryItem.OnItemBeginDrag += HandleBeginDrag;
        inventoryItem.OnItemDropped += HandleItemInteraction;
        inventoryItem.OnItemDrag += HandleDrag;
        inventoryItem.OnItemEndDrag += HandleEndDrag;
        inventoryItem.OnItemBeginHover += HandleBeginHover;
        inventoryItem.OnItemEndHover += HandleEndHover;
    }

    public InventoryItem AddItemToInventory()
    {
        for (int i = 0; i < inventoryList.Count; i++)
        {
            InventoryItem inventoryItem = inventoryList[i];
            if (inventoryItem == null || inventoryItem.itemInitialized)
            {
                continue;
            }
            else
            {
                inventoryItem.itemInitialized = true;
                return inventoryItem;
            }
        }
        return null;
    }

    public void CreateOrDestroyGhostItem(bool val, InventoryItem inventoryItem)
    {
        if (val)
        {
            ghostImage = Instantiate(ghostImagePrefab, mouseFollower.gameObject.transform);
            Image image =  ghostImage.GetComponent<Image>();
            image.sprite = inventoryItem.itemImage.sprite;
            image.color = new Color(inventoryItem.itemImage.color.r, inventoryItem.itemImage.color.g, inventoryItem.itemImage.color.b, 0.6f);
        }
        else
        {
            Destroy(ghostImage);
        }
    }

    public void HandleItemSelection(InventoryItem item)
    {
        Debug.Log("Freaky Jumpscare");
    }
    public void HandleBeginDrag(InventoryItem item)
    {
        if (!item.itemInitialized) return;
        currentlyDraggingItem = true;
        CreateOrDestroyGhostItem(true, item);
        mouseFollower.Toggle(true);
        Debug.Log("Begin Drag");
    }

    public void HandleEndDrag(InventoryItem item)
    {
        CreateOrDestroyGhostItem(false, item);
        mouseFollower.Toggle(false);
        currentlyDraggingItem = false;
        Debug.Log("End Drag");
    }

    public void HandleDrag(InventoryItem item)
    {
        Debug.Log(ghostImage.transform.localPosition);
    }

    public void HandleItemInteraction(InventoryItem item)
    {
        Debug.Log("Dropped Item");
    }

    public void HandleBeginHover(InventoryItem item)
    {
        currentlyHoveringItem = true;
        Debug.Log("Hovering item");
    }

    public void HandleEndHover(InventoryItem item)
    {
        currentlyHoveringItem = false;
        Debug.Log("End Hovering Item");
    }
}
