using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using ItemGroup;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UI.Presenter;
public delegate void testingDG();
public class Test_Slot : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerEnterHandler
{
    public testingDG DG;
    Test_Inventory inventory;
    Item item;
    SlotType type;
    Image slotImage;
    Text countText;
    GameObject dragObject;
    DragItem dragitem;

    public int count;
    public int ItemCount { get; private set; }
    public bool IsEmpty { get; private set; }

    public void Initialze(Test_Inventory inven, SlotType invenType,Item item)
    {
        
        inventory = inven;
        type = invenType;
        this.item = item;
        dragObject = GameObject.FindGameObjectWithTag("DragItem");
        dragitem = dragObject.GetComponent<DragItem>();
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
        if (item.ItemType == ItemType.Consume || item.ItemType == ItemType.Resource)
            countText.text = ItemCount.ToString();

        count = ItemCount;
    }

    public bool AddItem(Item item)
    {
        if(this.item.Name.Equals(item.Name) && !IsEmpty 
            && ItemCount < item.ItemMaxCount
            && item.ItemType != ItemType.Weapon
            && item.ItemType != ItemType.Shield
            && item.ItemType != ItemType.Module)
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
       if(eventData.button == PointerEventData.InputButton.Left && item.ItemType != ItemType.Default)
        {
            dragObject.transform.position = Input.mousePosition;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && ItemCount != 0)
        {
            
            UseItem();
        }
    }

    public void UseItem()
    {
        if(DG != null)
        DG();
        ItemCount--;
        if (ItemCount == 0)
        {
            item = ItemController.Instance.GetItem(0);
            IsEmpty = true;
        }
        SlotUpdate();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && item != null)
        {
            dragObject.SetActive(true);
            dragObject.transform.position = Input.mousePosition;
            dragitem.DragImage.sprite = item.Sprite;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        dragitem.slot = this;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && item != null)
        {
            SlotSwap(this, dragitem.slot);
            SlotUpdate();
            dragitem.slot.SlotUpdate();
            dragObject.SetActive(false);
        }
    }

    public void SlotSwap(Test_Slot slotA, Test_Slot slotB)
    {
        if (!CheckSwapable(slotA, slotB))
            return;
        if (slotB.type == SlotType.Consume)
        {
            ConnectSlot(slotA, slotB);
            return;
        }
        Item tempItem = new Item()
        {
            CodeNum = slotA.item.CodeNum,
            Name = slotA.item.Name,
            ItemType = slotA.item.ItemType,
            ItemMaxCount = slotA.item.ItemMaxCount,
            Sprite = slotA.item.Sprite
        };

        int tempItemCount = slotA.ItemCount;
        bool tempIsEmpty = slotA.IsEmpty;

        slotA.item = slotB.item;
        slotA.ItemCount = slotB.ItemCount;
        slotA.IsEmpty = slotB.IsEmpty;

        slotB.item = tempItem;
        slotB.ItemCount = tempItemCount;
        slotB.IsEmpty = tempIsEmpty;

    }

    public void ConnectSlot(Test_Slot slotA,  Test_Slot slotB)
    {
        slotB.item = slotA.item;
        slotA.DG = new testingDG(slotB.UseItem);
        slotB.DG = new testingDG(slotA.UseItem);

       
    }

    bool CheckSwapable(Test_Slot slotA, Test_Slot slotB)
    {
        if(slotA.type == slotB.type)
            return true;
        if (slotB.type == SlotType.Inventory && slotA.item.ItemType == slotB.item.ItemType)
            return true;           
        if (slotA.item.ItemType.ToString().Equals(slotB.type.ToString()))
        {
            return true;
        }
        return false;
    }
}
