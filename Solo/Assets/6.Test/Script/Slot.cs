using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UI.Presenters;
using UI.Presenter;
using ItemGroup;



public class Slot : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerEnterHandler
{

    protected IInventory inventory;
    protected Item item;
    protected SlotType type;
    protected Image slotImage;
    protected Text countText;
    protected GameObject dragObject; 
    protected DragItem dragItem;
    
    public int ItemCount { get; protected set; }
    public bool IsEmpty { get; protected set; }

    public void Initialize(IInventory inven, SlotType invenType,Item item)
    {
        inventory = inven;
        type = invenType;
        this.item = item;
        dragObject = GameObject.FindGameObjectWithTag("DragItem");
        dragItem = dragObject.GetComponent<DragItem>();
        slotImage = GetComponent<Image>();
        countText = GetComponentInChildren<Text>(); 
    }

    void SlotUpdate()
    {
        if (item.CodeNum == 0)
        {
            IsEmpty = true;
        }
        slotImage.sprite = item.Sprite;
        countText.text = string.Empty;
        if (item.ItemType == ItemType.Consume || item.ItemType == ItemType.Resource)
            countText.text = ItemCount.ToString();
    }

    public bool AddItem(Item item)
    {
        if (this.item.Name.Equals(item.Name) && !IsEmpty
            && ItemCount < item.ItemMaxCount
            && item.ItemType != ItemType.Weapon
            && item.ItemType != ItemType.Shield
            && item.ItemType != ItemType.Module)
        {
            ItemCount++;
            SlotUpdate();
            return true;
        }
        if (IsEmpty)
        {
            this.item = item;
            ItemCount++;
            IsEmpty = false;
            SlotUpdate();
            return true;
        }
        return false;
    }
    void UseItem()
    {

        ItemCount--;
        if (ItemCount == 0)
        {
            item = ItemController.Instance.GetItem(0);
            IsEmpty = true;
        }
        SlotUpdate();
    }

    void SlotSwap(Slot slotA, Slot slotB)
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

    public void ConnectSlot(Slot slotA, Slot slotB)
    {


    }

    bool CheckSwapable(Slot slotA, Slot slotB)
    {
        if (slotA.type == slotB.type)
            return true;
        if (slotB.type == SlotType.Inventory && slotA.item.ItemType == slotB.item.ItemType)
            return true;
        if (slotA.item.ItemType.ToString().Equals(slotB.type.ToString()))
        {
            return true;
        }
        return false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && item.ItemType != ItemType.Default)
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
    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && item != null)
        {
            dragObject.SetActive(true);
            dragObject.transform.position = Input.mousePosition;
            dragItem.DragImage.sprite = item.Sprite;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        dragItem.slot2 = this;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && item != null)
        {
            SlotSwap(this, dragItem.slot2);
            SlotUpdate();
            dragItem.slot2.SlotUpdate();
            dragObject.SetActive(false);
        }
    }

}

