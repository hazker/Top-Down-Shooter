using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CPUController : PlayerStats
{
    public HumanController human;

    Ray ray;
    RaycastHit hit;

    NavMeshAgent agent;

    public Transform raycastStartSpot;

    [SerializeField]
    float dist;

    [HideInInspector]
    public bool trickshot = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        MovSpeed(true);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        myTime = myTime + Time.deltaTime;
        dist = Vector3.Distance(human.transform.position, transform.position);

        MakeDesicion();

        transform.LookAt(human.transform.position);

    }

    public void DoTrickShot()
    {
        if (agent.enabled)
        {
            Shooting();
        }
            
    }

    public void MovSpeed(bool b)
    {
        if (b)
        {
            agent.enabled = true;
            agent.speed = walkingSpeed;
        }
        else
        {
            agent.speed = 0;
            agent.enabled = false;
        }
    }


    void MakeDesicion()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 999f))
        {
            if (hit.transform.tag == "Player")
            {
                Shooting();
            }
            if (hit.transform.tag != "Player" && canMove && !trickshot)
            {
                Movement();

            }
        }

    }

    public override void Movement()
    {
        if (agent.enabled)
        {
            agent.speed = walkingSpeed;
            agent.SetDestination(human.transform.position);
        }

    }

    public override void TakeDamage()
    {
        InGameUI.instance.HumanScore();
        GameManager.instance.NewGame();
    }

    public override void Shooting()
    {
        if (myTime > nextFire)
        {
            gunC.raycastStartSpot = raycastStartSpot;
            gunC.Fire();
            myTime = 0;
        }
    }
}
