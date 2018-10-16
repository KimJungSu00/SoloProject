using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Test_InputManager : Singleton<Test_InputManager>
    {
        public Vector3 OnclickedArrowButton()
        {
            int left = 0;
            int up = 0;
            if (Input.GetKey(KeyCode.LeftArrow))
                left = -1;
            if (Input.GetKey(KeyCode.RightArrow))
                left = 1;
            if (Input.GetKey(KeyCode.UpArrow))
                up = -1;
            if (Input.GetKey(KeyCode.DownArrow))
                up = 1;
            Vector3 direction = new Vector3(up, 0, left);
            return direction;
        }

        public bool OnClickedRunButton()
        {
            if (Input.GetKey(KeyCode.LeftShift))
                return true;
            else
                return false;
        }

        public bool OnClickedJumpButton()
        {
            if (Input.GetKeyDown(KeyCode.Z))
                return true;

            return false;
        }

        public bool OnClickedAttackButton()
        {
            if (Input.GetKeyDown(KeyCode.X))
                return true;
            return false;
        }
    }
}