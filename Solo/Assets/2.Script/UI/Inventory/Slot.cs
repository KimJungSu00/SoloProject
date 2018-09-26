using UnityEngine;
using ItemGroup;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Presenter
{

    public class Slot : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {

        Inventory inventory;
        DragItem dragImage;
        Item item;
        public ItemType ItemType { get; protected set; }

        public int ItemCode { get; protected set; }
        Sprite defaultSprite;
        Image slotImage;
        Text countText;
        GameObject dragObject;
        int maxItemCount;
        public int ItemCount { get; private set; }
        public string ItemName { get; private set; }
        public bool IsEmpty;

        public void Initialze(int maxItemCount, Sprite defaultSprite)
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
            slotImage = GetComponent<Image>();
            countText = GetComponentInChildren<Text>();
            dragObject = GameObject.FindGameObjectWithTag("DragItem");
            dragImage = dragObject.GetComponent<DragItem>();
            this.defaultSprite = defaultSprite;
            this.maxItemCount = maxItemCount;
            ItemName = string.Empty;
            SlotUpdate();
        }

        public void SlotUpdate()
        {
            if (item == null)
            {
                slotImage.sprite = defaultSprite;
                IsEmpty = true;
                countText.text = string.Empty;
                ItemType = ItemType.Default;
                ItemCode = 0;
                return;
            }
            slotImage.sprite = item.Sprite;
            ItemName = item.Name;
            ItemType = item.ItemType;
            ItemCode = item.CodeNum;
            if (ItemType != ItemType.Equipment)
                countText.text = ItemCount.ToString();
            else
                countText.text = string.Empty;
        }

        public bool Additem(Item item)
        {
            if (ItemName.Equals(item.Name) && !IsEmpty && ItemCount < maxItemCount && ItemType != ItemType.Equipment)
            {
                ItemCount++;
                SlotUpdate();
                return true;
            }
            if (IsEmpty)
            {
                this.item = item;
                ItemCount++;
                SlotUpdate();
                IsEmpty = false;
                return true;
            }
            return false;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right && ItemCount != 0)
            {
                ItemCount--;
                if (ItemCount == 0)
                {
                    item = null;
                    IsEmpty = true;
                }
                SlotUpdate();
            }
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left && item != null)
            {
                dragObject.SetActive(true); 
                dragObject.transform.position = Input.mousePosition;
                dragImage.DragImage.sprite = item.Sprite;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left && item!=null)
            {
                SlotSwap(this, inventory.FindNearSlot(this, dragObject.transform.position));
                dragObject.SetActive(false);
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left && item != null)
            {
                dragObject.transform.position = Input.mousePosition;
            }
        }

        public void SlotSwap(Slot slotA, Slot slotB)
        {
            Item tempitem = slotA.item;
            int tempItemCount = slotA.ItemCount;
            bool tempIsEmpty = slotA.IsEmpty;

            slotA.item = slotB.item;
            slotA.ItemCount = slotB.ItemCount;
            slotA.IsEmpty = slotB.IsEmpty;

            slotB.item = tempitem;
            slotB.ItemCount = tempItemCount;
            slotB.IsEmpty = tempIsEmpty;

            slotA.SlotUpdate();
            slotB.SlotUpdate();
        }

        public void LoadSlot(int itemCode, int itemCount)   
        {
            ItemCode = itemCode;
            ItemCount = itemCount;
            item = ItemController.Instance.GetItem(itemCode);
            if (ItemCount != 0)
                IsEmpty = false;
            SlotUpdate();
        }
    }
}