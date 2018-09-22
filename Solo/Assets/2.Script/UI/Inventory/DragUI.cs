using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IDragHandler
{
    RectTransform rectTransform;
    [SerializeField]
    Vector2 offset;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = new Vector2(Input.mousePosition.x,Input.mousePosition.y - rectTransform.rect.height/2 + offset.y);
        }
    }
}
