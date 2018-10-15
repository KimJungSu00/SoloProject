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


    protected override void Move()
    {
        direction = Test_InputManager.Instance.OnclickedArrowButton();

        if (Test_InputManager.Instance.OnClickedRunButton())
        {
            moveSpeed = runSpeed;
            IsWalk = false;
            IsRun = true;
        }
        else
        {
            moveSpeed = walkSpeed;
            IsRun = false;
            IsWalk = true;     
        }
        if(direction == Vector3.zero || IsAttack)
        {
            IsRun = false;
            IsWalk = false;
            moveSpeed = 0;
        }
        velocity = direction * moveSpeed;
        if (!isGround)
        {
            velocity += Vector3.down * gravityPower;
        }
        rigidbody.velocity = velocity * Time.deltaTime;
    }

    protected void Rotate()
    {
        if (direction == Vector3.zero || IsAttack)
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

    void StartAttack()
    {
        IsAttack = true;
    }

    void EndAttack()
    {
        IsAttack = false;
    }

}
