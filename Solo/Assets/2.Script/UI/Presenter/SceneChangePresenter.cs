using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SideScroll.Manager;

namespace SideScroll.UI.Presenter
{

    public class SceneChangePresenter : MonoBehaviour
    {

        [SerializeField]
        StageStateType nextScene;

        public void OnClickedButton()
        {
            SceneManager.LoadScene(nextScene.ToString());
        }
    }
}
