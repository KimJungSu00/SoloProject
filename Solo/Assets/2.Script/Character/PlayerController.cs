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
    [SerializeField]
    float jumpPower;
    [SerializeField]
    float gravityPower;
    Status status;

    Rigidbody rigidBody;

    bool isGrounded = true;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        status = GetComponent<Status>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    Vector3 velocity = Vector3.zero;
    Vector3 direction = Vector3.zero;
    void Move()
    {
        direction = new Vector3(PlayerInputManager.Instance.InputArrow().x, 0, PlayerInputManager.Instance.InputArrow().z);

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
        velocity = direction * moveSpeed;
        if (!isGrounded)
            velocity += Vector3.down * gravityPower;
        
        if (velocity == new Vector3(0, velocity.y, 0) || status.isAttack)
        {
            status.isWalk = false;
            status.isRun = false;
            return;
        }
        
        if (velocity.z < 0)
        {
            rigidBody.rotation = Quaternion.Euler(new Vector3(0, 180));
        }
        else
            rigidBody.rotation = Quaternion.Euler(new Vector3(0, 0));



        rigidBody.velocity = velocity * Time.deltaTime;

    }

    


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;

    }


}

