using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UI.Presenters;
using ItemGroup;


public enum SlotType
{
    Weapon,
    Module,
    Shield,
    Inventory,
    Consume,
}

public class Slot : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerEnterHandler
{

    IInventory inventory;
    Item item;
    SlotType type;
    Image slotImage;
    Text countText;
    GameObject dragObject;
    DragItem dragItem;

    public int index;
    public int ItemCount { get; protected set; }
    public bool IsEmpty { get; protected set; }
    public int ItemCode { get { return item.CodeNum; } private set { } }
    public void Initialize(IInventory inven, SlotType invenType, Item item, int index)
    {
        inventory = inven;
        type = invenType;
        this.item = item;
        this.index = index;
        IsEmpty = true;
        dragObject = GameObject.FindGameObjectWithTag("DragItem");
        dragItem = dragObject.GetComponent<DragItem>();
        slotImage = GetComponent<Image>();
        countText = GetComponentInChildren<Text>();

        slotImage.sprite = item.Sprite;
        GameDataManager.Instance.AddData(index, item.CodeNum, ItemCount,type);
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

        
            GameDataManager.Instance.UpdateData(index,item.CodeNum,ItemCount,type);
        
    }

    public void LoadItem(Item item,int count)
    {
        this.item = item;
        ItemCount = count;
        IsEmpty = false;
        SlotUpdate();
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
    public void UseItem()
    {
        if (ItemCount == 0)
            return;
        ItemCount--;
        if (ItemCount == 0)
        {
            item = ItemController.Instance.GetItem(0);
            IsEmpty = true;
        }
        SlotUpdate();
    }

    public void SlotSwap(Slot slotA, Slot slotB)
    {
        if (!CheckSwapable(slotA, slotB))
            return;
        
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
        int tempIndex = slotA.index;

        slotA.item = slotB.item;
        slotA.ItemCount = slotB.ItemCount;
        slotA.IsEmpty = slotB.IsEmpty;

        slotB.item = tempItem;
        slotB.ItemCount = tempItemCount;
        slotB.IsEmpty = tempIsEmpty;


        slotA.SlotUpdate();
        slotB.SlotUpdate();
        GameDataManager.Instance.LoadData();
    }


    bool CheckSwapable(Slot slotA, Slot slotB)
    {
        if (slotA.type == slotB.type)
            return true;
        if (slotB.type == SlotType.Inventory )
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
        dragItem.slot = this;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && item != null)
        {
            SlotSwap(this, dragItem.slot);
            dragObject.SetActive(false);
        }
    }

}

