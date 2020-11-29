using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerStats : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public GunController gunC;
    

    protected float nextFire = 0.5F;
    protected float myTime = 0.0F;
    protected Rigidbody rb;
    protected Vector3 moveDirection = Vector3.zero;
    protected Vector3 moveVelocity;

    public bool canMove = true;

    public abstract void Movement();

    public abstract void TakeDamage();

    public abstract void Shooting();
}
