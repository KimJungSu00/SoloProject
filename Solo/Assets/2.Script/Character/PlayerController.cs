using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    float moveSpeed;
    [SerializeField]
    float walkSpeed;
    [SerializeField]
    float runSpeed;
    
    Status status;

    Rigidbody rigidBody;
   
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        status = GetComponent<Status>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    bool right = true;
    void Move()
    {/*
            Vector3 direction = new Vector3(MoveInput.x, 0, MoveInput.y);
            direction = Quaternion.Euler(0, horizontalAngle, 0) * direction;
            if (MoveInput == Vector2.zero || status.isAttack)
            {
                status.isWalk = false;
                return;
            }

            status.isWalk = true;
            rigidBody.velocity = direction * MoveSpeed * Time.deltaTime;
            Quaternion newRotation = Quaternion.LookRotation(direction);
            rigidBody.rotation = Quaternion.Slerp(rigidBody.rotation, newRotation, RotationSpeed * Time.deltaTime);
            */
        Vector3 gravity = new Vector3(0, -1.8f, 0);

        Vector3 direction = new Vector3(PlayerInputManager.Instance.InputArrow().x,0, PlayerInputManager.Instance.InputArrow().z);
        if (direction == Vector3.zero || status.isAttack)
        {
            status.isWalk = false;
            status.isRun = false;
            return;
        }
        if (direction.z <0)
        {
            rigidBody.rotation = Quaternion.Euler(new Vector3(0, 180));
        }
        else
            rigidBody.rotation = Quaternion.Euler(new Vector3(0, 0));
        if (PlayerInputManager.Instance.InputArrow().y == 1)
        {
            moveSpeed = runSpeed;
            status.isRun = true;
        }
        else
        {
            moveSpeed = walkSpeed;
            status.isWalk = true;
        }
        rigidBody.velocity = direction * moveSpeed * Time.deltaTime;

    }

}
