using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePanel : MonoBehaviour {

    [SerializeField]
    GameObject UIPanel;

    public void OnClickedCloseButton()
    {
        UIPanel.SetActive(false);
    }
	
}
