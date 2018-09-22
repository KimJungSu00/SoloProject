using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SideScroll.Manager;
namespace SideScroll.System
{
    public class ManagerAwaker : MonoBehaviour
    {
        void Awake()
        {
            PlayerInputManager.Instance.Initialize();
            GameControllManager.Instance.Initialize();
            GameDataManager.Instance.Initialize();
           
        }

    }
}
