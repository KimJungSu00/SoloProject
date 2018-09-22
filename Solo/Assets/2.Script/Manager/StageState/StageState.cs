using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SideScroll.Manager.Stage
{
    public abstract class StageState
    {

        abstract public void Enter();
        abstract public void Do();
        abstract public void Exit();
        
    }
}
