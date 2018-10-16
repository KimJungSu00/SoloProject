using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DragItem : MonoBehaviour
{
    public int PreSlotIndex;
    public Image DragImage;
    private void Awake()
    {
        DragImage = GetComponent<Image>();
    }
}
