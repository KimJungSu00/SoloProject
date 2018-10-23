using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.View
{
    public class Slot : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler, IEndDragHandler, IPointerDownHandler
    {
        protected DragItem dragItem;

        public Image ItemImage;
        public int Index;
        public Text ItemCount;

        public void SlotInitialize()
        {
            dragItem = GameObject.FindGameObjectWithTag("DragItem").GetComponent<DragItem>();
            ItemImage = GetComponent<Image>();
            ItemCount = GetComponentInChildren<Text>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            dragItem.gameObject.SetActive(true);
            dragItem.ItemImage.sprite = ItemImage.sprite;
        }

        public void OnDrag(PointerEventData eventData)
        {
            dragItem.gameObject.transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            dragItem.gameObject.SetActive(false);
        }

        public virtual void OnDrop(PointerEventData eventData)
        { }

        public virtual void OnPointerDown(PointerEventData eventData)
        {  }

    }
}
