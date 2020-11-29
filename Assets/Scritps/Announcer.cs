using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Announcer : MonoBehaviour
{
    public float timeToAnnouncement = 5f;
    public Text Announcment;
    public static Announcer instance;

    string announcement="";
    float myTimer;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        myTimer += Time.deltaTime;
        if (myTimer > timeToAnnouncement)
        {
            myTimer = 0;
            MakeAnnouncment();
            announcement = "";
        }
            
    }

    public void Fire()
    {
        if (Input.GetButton("Fire1") && !announcement.Contains(" выстрел;"))
        {
            announcement +=" выстрел;";
        }
    }

    public void Aim()
    {
        if (Input.GetButton("Fire2") && !announcement.Contains(" в режиме прицелевания;"))
        {
            announcement += " в режиме прицелевания;";
        }
    }

    public void Strafe()
    {
        if (Input.GetAxis("Horizontal") > 0 && !announcement.Contains(" боковое перемещение;"))
        {
            announcement += " боковое перемещение;";
        }
    }

    public void Movement()
    {

        if (Input.GetAxis("Vertical") > 0 && !announcement.Contains(" перемещение;"))
        {
            announcement += " перемещение;";
        }
    }

    public void Ricochet()
    {
        if (!announcement.Contains(" рикошет;"))
        {
            announcement += " рикошет;";
        }
            
    }

    public void Razvorot()
    {
        if (!announcement.Contains(" разворот;"))
        {
            announcement+=" разворот;";
        }
    }

    void MakeAnnouncment()
    {
        Announcment.text = announcement;
    }
}
