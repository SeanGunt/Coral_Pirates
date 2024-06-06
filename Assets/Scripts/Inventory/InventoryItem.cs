using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerClickHandler,
        IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    [HideInInspector] public Image itemImage;
    [HideInInspector] public bool itemInitialized;
    public event Action<InventoryItem> OnItemBeginDrag, OnItemEndDrag, OnItemDropped, OnItemClicked, OnItemBeginHover, OnItemEndHover;

    private void Start()
    {
        itemImage = GetComponent<Image>();
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
