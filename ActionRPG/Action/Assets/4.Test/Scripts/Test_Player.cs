using UnityEngine;

public class Test_Player : Test_Character
{

    public int EquipmentSTK;
    public int EquipmentDEF;

    protected override void UpdateStatus()
    {
        base.UpdateStatus();
        totalStrikingPower += EquipmentSTK;
        totalDefensivePower += EquipmentDEF;
    }

    private void FixedUpdate()
    {
        
        Move();
        Rotate();
    }

    Vector3 velocity = Vector3.zero;
    Vector3 direction = Vector3.zero;

    bool isRun;
    protected override void Move()
    {
        direction = Test_InputManager.Instance.OnclickedArrowButton(); 
        
        if(Test_InputManager.Instance.OnClickedRunButton())
        {
            moveSpeed = runSpeed;
            isRun = true;
        }
        else
        {
            moveSpeed = walkSpeed;
            isRun = false;
        }
        velocity = direction * moveSpeed;
        rigidbody.velocity = velocity * Time.deltaTime;
    }

    protected void Rotate()
    {
        if (direction == Vector3.zero)
            return;
        if (direction.z < 0)
        {
            rigidbody.rotation = Quaternion.Euler(new Vector3(0, 180));
        }
        else
        {
            rigidbody.rotation = Quaternion.Euler(new Vector3(0, 0));
        }
    }
}
