using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler,
        IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;
    public Image backgroundImage;
    public bool itemInitialized;
    public bool itemUsed;
    public event Action<InventoryItem> OnItemBeginDrag, OnItemEndDrag, OnItemDropped, OnItemClicked, OnItemBeginHover, OnItemEndHover, OnItemDrag;

    private void Start()
    {
        itemImage = GetComponent<Image>();
    }

    public void ItemUsed()
    {
        itemUsed = true;
        itemImage.color = Color.gray;
        backgroundImage.color = Color.gray;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        OnItemBeginDrag?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnItemEndDrag?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnItemDropped?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnItemDrag?.Invoke(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnItemClicked?.Invoke(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnItemBeginHover?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnItemEndHover?.Invoke(this);
    }
}
