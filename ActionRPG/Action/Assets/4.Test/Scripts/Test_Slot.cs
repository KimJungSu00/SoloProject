using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Test
{
    public enum SlotType
    {
        Inventory,
        Equipment,
        QuickSlot,
    }
    public class Test_Slot : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler, IEndDragHandler
    {
        // [HideInInspector]
        public Image slotImage;
        [HideInInspector]
        public int index;
        [HideInInspector]
        public Text CountText;

        public SlotType type { get; protected set; }
        protected DragItem dragitem;

        protected virtual void Awake()
        {
            dragitem = GameObject.FindGameObjectWithTag("DragItem").GetComponent<DragItem>();
            slotImage = GetComponent<Image>();
            CountText = GetComponentInChildren<Text>();
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
            dragitem.gameObject.SetActive(true);
            dragitem.DragImage.sprite = slotImage.sprite;
            dragitem.PreSolt = this;
        }

        public void OnDrag(PointerEventData eventData)
        {
            dragitem.gameObject.transform.position = Input.mousePosition;
        }

        public virtual void OnDrop(PointerEventData eventData)
        { }

        public void OnEndDrag(PointerEventData eventData)
        {
            dragitem.gameObject.SetActive(false);
        }
    }

}
