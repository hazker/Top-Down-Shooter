using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicochetBullet : Bullet
{
    public float damage;
    public string weaponName;
    public Transform instPos;
    public Transform bulletPos;
    Vector3 lastvelocity;


    public bool prodByHuman = false;

    float myTime;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            if (prodByHuman)
                Announcer.instance.Ricochet();
            var speed = lastvelocity.magnitude;
            var direction = Vector3.Reflect(lastvelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0f);
        }

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "CPU")
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage();
            Destroy(this.gameObject);
        }

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        lastvelocity = rb.velocity;
        myTime = myTime + Time.deltaTime;
        if (myTime > lifetime)
        {
            Destroy(this.gameObject);
        }


    }

}
