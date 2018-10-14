using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : Singleton<PlayerInputManager>
{

    float lastTapTime;
    float tapSpeed = 0.5f;
    int run;

    float latency;
    bool doubleClick = false;
    [SerializeField]
    QuickInventory Quickslot;

    private void Update()
    {
        UseQuickSlot();
    }
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
        }


        return direction;
    }

    bool CheckArrowDoubleClick()
    {
        bool doubleclick = false;
        if (Input.GetKeyDown(KeyCode.LeftShift))
            return true;
        
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

    public bool AttackButton()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            return true;
        }

        return false;
    }

    public bool JumpButton()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            return true;
        }

        return false;
    }

    void UseQuickSlot()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Quickslot.UseItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Quickslot.UseItem(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Quickslot.UseItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Quickslot.UseItem(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Quickslot.UseItem(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Quickslot.UseItem(6);
        }
    }
    
}

