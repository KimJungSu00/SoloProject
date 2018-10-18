using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Test_Character : MonoBehaviour
{

   

    protected Rigidbody rigidbody;

    protected bool isGround;
    [SerializeField]
    protected float gravityPower;

    protected float moveSpeed;
    [SerializeField]
    protected float walkSpeed;
    [SerializeField]
    protected float runSpeed;

    protected Vector3 velocity = Vector3.zero;
    protected Vector3 direction = Vector3.zero;

    public bool IsWalk { get; protected set; }
    public bool IsRun { get; protected set; }
    public bool IsAttack { get; protected set; }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    protected abstract void Move();

    private void OnCollisionEnter(Collision collision)
    {
        isGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        isGround = false;
    }
}
