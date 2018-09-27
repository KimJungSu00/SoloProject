using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ItemGroup;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Test_Slot : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerEnterHandler
{
    Test_Inventory inventory;
    Item item;
    SlotType type;
    Image slotImage;
    Text countText;
    
    public int ItemCount { get; private set; }
    public bool IsEmpty { get; private set; }

    public void Initialze(Test_Inventory inven, SlotType invenType,Item item)
    {
        inventory = inven;
        type = invenType;
        this.item = item;
        slotImage = GetComponent<Image>();
        countText = GetComponentInChildren<Text>();
        SlotUpdate();
    }

    void SlotUpdate()
    {
        if(item.CodeNum == 0)
        {
            IsEmpty = true;     
        }
        slotImage.sprite = item.Sprite;
        countText.text = string.Empty;
        if (item.ItemType != ItemType.Equipment && item.ItemType != ItemType.Default)
            countText.text = ItemCount.ToString();
    }

    public bool AddItem(Item item)
    {
        if(this.item == item && !IsEmpty 
            && ItemCount < item.ItemMaxCount
            && item.ItemType != ItemType.Equipment)
        {
            ItemCount++;
            SlotUpdate();
            return true;
        }
        if(IsEmpty)
        {
            this.item = item;
            ItemCount++;
            IsEmpty = false;
            SlotUpdate();
            return true;
        }
        return false;
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      
    }
}
