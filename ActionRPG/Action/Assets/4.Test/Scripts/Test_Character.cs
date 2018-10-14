using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Test_Character : MonoBehaviour {

	public int HealthPoiont { get; protected set; }
    public int ManaPoint { get; protected set; }

    protected int totalStrikingPower;
    protected int totalDefensivePower;

    [SerializeField]
    protected int strength;
    [SerializeField]
    protected int intelligence;
    [SerializeField]
    protected int constitution;
    [SerializeField]
    protected int will;

    protected Rigidbody rigidbody;
    [SerializeField]
    bool isGround;
    
    protected float moveSpeed;
    [SerializeField]
    protected float walkSpeed;
    [SerializeField]
    protected float runSpeed;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void UpdateStatus()
    {
        HealthPoiont = (constitution * 10);
        ManaPoint = (intelligence * 10);
        totalStrikingPower = (strength * 10);
        totalDefensivePower = (will * 5);
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
