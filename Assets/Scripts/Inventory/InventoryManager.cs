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
    [HideInInspector] public bool currentlyHoveringItem = false;
    [HideInInspector] public string nameOfSelectedItem;
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

    private void GetDraggedItem(InventoryItem item)
    {
        GameObject itemGameobject = item.transform.GetChild(0).gameObject;
        nameOfSelectedItem = itemGameobject.name;
        Debug.Log(nameOfSelectedItem);
    }

    private void ResetDraggedItem()
    {
        nameOfSelectedItem = "";
    }

    private IEnumerator MovePlayerToInteractionPoint(Vector3 targetPosition, ItemInteractor itemInteractor)
    {
        GameManager.instance.player.GetComponent<PlayerPointClick>().SetTarget(targetPosition);
        while (!itemInteractor.closeToClickable)
        {
            yield return null;
        }
        itemInteractor?.Interact();
        ResetDraggedItem();
    }

    public void HandleItemSelection(InventoryItem item)
    {
        Debug.Log("Freaky Jumpscare");
    }
    public void HandleBeginDrag(InventoryItem item)
    {
        if (!item.itemInitialized) return;
        CreateOrDestroyGhostItem(true, item);
        GetDraggedItem(item);
        mouseFollower.Toggle(true);
        Debug.Log("Begin Drag");
    }

    public void HandleEndDrag(InventoryItem item)
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            ItemInteractor itemInteractor = hit.collider.GetComponent<ItemInteractor>();
            if (itemInteractor != null)
            {
                StartCoroutine(MovePlayerToInteractionPoint(hit.collider.transform.position, itemInteractor));
            }
        }
        CreateOrDestroyGhostItem(false, item);
        mouseFollower.Toggle(false);
        Debug.Log("End Drag");
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
