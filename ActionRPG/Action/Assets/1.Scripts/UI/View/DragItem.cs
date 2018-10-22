using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.View
{
    public class DragItem : MonoBehaviour
    {
        public Image ItemImage;

        private void Awake()
        {
            ItemImage = GetComponent<Image>();
        }

    }
}
