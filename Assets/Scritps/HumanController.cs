using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : PlayerStats
{

    public float mouseSensitivity = 0.5f;
    public Camera cam;

    public Transform raycastStartSpot;

    Vector3 oldPoint=Vector3.zero;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            Movement();
            Shooting();
        }
        else
        {
            moveVelocity = Vector3.zero;
        }
    }

    public override void Movement()
    {
        
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveVelocity = moveDirection * walkingSpeed;
        Announcer.instance.Movement();
        Announcer.instance.Strafe();
        
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.up, transform.position);
        float rayl;
        
        if (plane.Raycast(ray, out rayl))
        {
            Vector3 pointToLook = ray.GetPoint(rayl);
            Debug.DrawRay(ray.origin, pointToLook, Color.red);
            if(pointToLook.z- oldPoint.z > 0.01f)
            {
                Announcer.instance.Razvorot();
            }

            transform.LookAt(pointToLook);
            oldPoint = pointToLook;
        }
    }

    public override void Shooting()
    {

        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire)
        {
            Announcer.instance.Fire();
            gunC.Fire();
            myTime = 0;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }

    public override void TakeDamage()
    {
        InGameUI.instance.CPUGetScore();
        GameManager.instance.NewGame();
    }


}
