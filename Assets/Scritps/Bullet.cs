using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float initialForce;
    public float lifetime;

    protected Rigidbody rb;
    protected float lifeTimer;
}
