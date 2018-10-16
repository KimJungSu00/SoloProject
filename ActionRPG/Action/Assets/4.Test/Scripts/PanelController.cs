using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Test
{
    public class PanelController : MonoBehaviour
    {
        [SerializeField]
        GameObject panel;
        public void OnClickedClosedButton()
        {
            panel.SetActive(false);
        }

    }
}
