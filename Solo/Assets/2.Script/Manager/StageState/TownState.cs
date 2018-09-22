using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SideScroll.Manager;

namespace SideScroll.Manager.Stage
{
    public class TownState : StageState
    {
  
        public override void Enter()
        {
            UIControllManager.Instance.StartLoading();
        }
        public override void Do()
        {

        }
        public override void Exit()
        {
            UIControllManager.Instance.EndLoading();
        }
    }
}
