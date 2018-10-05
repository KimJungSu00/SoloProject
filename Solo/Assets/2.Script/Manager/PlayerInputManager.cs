using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInputManager : Singleton<PlayerInputManager>
{

    float lastTapTime;
    float tapSpeed = 0.5f;

    int run = 0;
    float latency;
    bool doubleClick = false;
    float time;
    public Vector3 InputArrow()
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
        if (CheckArrowDoubleClick())
            run = 1;
        Vector3 direction = new Vector3(up, run, left);
        if (direction.x == 0 && direction.z == 0)
        {
            doubleClick = false;
            run = 0;
            //  Debug.Log("달리기 종료");
        }


        return direction;
    }

    bool CheckArrowDoubleClick()
    {
        bool doubleclick = false;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && !doubleClick)
        {
            doubleClick = true;
            latency = Time.time - lastTapTime;
            if (latency < tapSpeed)
                doubleclick = true;
            lastTapTime = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !doubleClick)
        {
            doubleClick = true;
            latency = Time.time - lastTapTime;
            if (latency < tapSpeed)
                doubleclick = true;
            lastTapTime = Time.time;
        }
        return doubleclick;
    }


}

