using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SideScroll.Manager
{
    public enum ButtonType
    {
        StageChange,
        PlayerInfo,
        Inventory,
        Skill,
    }
    public class UIControllManager : Singleton<UIControllManager>
    {
        [SerializeField]
        GameObject loadingPanel;

        private void Awake()
        {
           DontDestroyOnLoad(gameObject);
        }

        public void StartLoading()
        {
            loadingPanel.SetActive(true);
        }

        public void EndLoading()
        {
            loadingPanel.SetActive(false);
        }

    }

}