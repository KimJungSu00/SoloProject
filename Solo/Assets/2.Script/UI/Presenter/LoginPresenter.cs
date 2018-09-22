using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SideScroll.UI.Presenter
{
    public class LoginPresenter : MonoBehaviour
    {
        string adminID = "Admin";
        string adminPW = "Admin";

        [SerializeField]
        GameObject loginBG;
        [SerializeField]
        GameObject startButton;

        [SerializeField]
        Text id;
        [SerializeField]
        Text password;

        bool isSuccessLogin;
        public void OnClickSign()
        {
            
        }

        public void OnClickLogin()
        {
            loginBG.SetActive(false);
            startButton.SetActive(true);
            /*
            if(id.text.Equals(adminID) && password.text.Equals(adminPW))
            {
                loginBG.SetActive(false);
                startButton.SetActive(true);
            }*/
        }
    }
}
