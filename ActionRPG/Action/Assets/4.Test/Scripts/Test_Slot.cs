using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Test
{
    public class Test_Slot : MonoBehaviour, IDragHandler, IBeginDragHandler, IDropHandler, IEndDragHandler
    {
       // [HideInInspector]
        public Image slotImage;
        [HideInInspector]
        public int index;       
        [HideInInspector]
        public Text CountText;

        protected Image dragitem;

        protected virtual void Awake()
        {
            dragitem = GameObject.FindGameObjectWithTag("DragItem").GetComponent<Image>();
            slotImage = GetComponent<Image>();
            CountText = GetComponentInChildren<Text>();
        }

        public virtual void OnBeginDrag(PointerEventData eventData)
        {
                dragitem.gameObject.SetActive(true);
                dragitem.sprite = slotImage.sprite;
        }

        public void OnDrag(PointerEventData eventData)
        {
            dragitem.gameObject.transform.position = Input.mousePosition;
        }

        public virtual void OnDrop(PointerEventData eventData)
        {}

        public void OnEndDrag(PointerEventData eventData)
        {
            dragitem.gameObject.SetActive(false);
        }
    }

}
