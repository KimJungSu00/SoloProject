using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Test
{
    public class Test_Slot : MonoBehaviour , IDragHandler , IBeginDragHandler, IDropHandler
    {
        public Image slotImage;
        public int index;
        Test_Inventory inventory;
        DragItem dragitem;
        public Text CountText;
        private void Awake()
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Test_Inventory>();
            dragitem = GameObject.FindGameObjectWithTag("DragItem").GetComponent<DragItem>();
            slotImage = GetComponent<Image>();
            CountText = GetComponentInChildren<Text>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            dragitem.gameObject.SetActive(true);
            dragitem.PreSlotIndex = index;
            dragitem.DragImage.sprite = slotImage.sprite;
        }

        public void OnDrag(PointerEventData eventData)
        {
            dragitem.gameObject.transform.position = Input.mousePosition;
        }

        public void OnDrop(PointerEventData eventData)
        {
            inventory.Swap(dragitem.PreSlotIndex, index);
            dragitem.gameObject.SetActive(false);
        }

      

    }
   
}
