using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SideScroll.Manager;

public class StartMain : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameControllManager.Instance.ChangeStageState(StageStateType.Town);
	}

}
