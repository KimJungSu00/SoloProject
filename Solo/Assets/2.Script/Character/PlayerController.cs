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
    float gravityPower;
    Status status;


    //Animator State
    [HideInInspector]
    public bool isWalk;
    [HideInInspector]
    public bool isAttack;
    [HideInInspector]
    public bool isRun;
    
    public bool isAlive = true;
    Rigidbody rigidBody;

    bool isGrounded = true;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        status = GetComponent<Status>();
    }
    private void FixedUpdate()
    {
        if (isAlive)
        {
            Move();
            StartDeath();
        }
    }

    Vector3 velocity = Vector3.zero;
    Vector3 direction = Vector3.zero;
    void Move()
    {
        direction = new Vector3(PlayerInputManager.Instance.InputArrow().x, 0, PlayerInputManager.Instance.InputArrow().z);

        if (PlayerInputManager.Instance.InputArrow().y == 1)
        {
            moveSpeed = runSpeed;
            isRun = true;
        }
        else
        {
            moveSpeed = walkSpeed;
            isWalk = true;
        }
        velocity = direction * moveSpeed;
        if (!isGrounded)
            velocity += Vector3.down * gravityPower;
        
        if (velocity == new Vector3(0, velocity.y, 0) || isAttack)
        {
            isWalk = false;
            isRun = false;
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

    void StartAttack()
    {
        isAttack = true;
    }
    void EndAttack()
    {
        isAttack = false;
    }
    void StartDeath()
    {
        if(status.HealthPoint<=0)
        {
            isAlive = false;
        }
        
    }
}

