using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GunController : MonoBehaviour
{

    public GameObject projectile;
    public float initialForce;
    public CPUController cpu;
    public Transform raycastStartSpot;

    public void Fire()
    {

        Rigidbody rigidbody = Instantiate(projectile, raycastStartSpot.position, raycastStartSpot.rotation).GetComponent<Rigidbody>();
        rigidbody.AddForce(raycastStartSpot.forward*initialForce);

    }

}
