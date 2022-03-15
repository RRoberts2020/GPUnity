using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public AudioSource OpenDoorSound;
    public GameObject LeftDoor;
    public Animator LD;
    public GameObject RightDoor;
    public Animator RD;
    public bool EnterTrigger;
    public bool IsDoorOpen;
    public GameObject OpenLight;
    public GameObject ClosedLight;
    public GameObject CutcutsceneCam;
    public GameObject NormalCam;


    static int DoorState;
    

    void Start()
    {
        DoorState = 0;

        LeftDoor = GameObject.FindGameObjectWithTag("LeftDoor");
        LD = LeftDoor.GetComponent<Animator>();
        RightDoor = GameObject.FindGameObjectWithTag("RightDoor");
        RD = RightDoor.GetComponent<Animator>();

    }

    void Update()
    {
        if (EnterTrigger)
        {
            DoorActive();
            StartCoroutine(LightTimer());
            StartCoroutine(CutSceneTimer());
        }
    }
    


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnterTrigger = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnterTrigger = false;

        }
    }

    void DoorActive()
    {

            if (Input.GetButtonDown("LeftAttack") && EnterTrigger == true)
            {
                DoorState++;

                if (DoorState == 1)
                {
                    LD.SetBool("Open", true);
                    RD.SetBool("Open", true);
                    LD.SetBool("Closed", false);
                    RD.SetBool("Closed", false);
                    
                    IsDoorOpen = true;
                    EnterTrigger = false;

            }

                if (DoorState == 2)
                {
                    LD.SetBool("Open", false);
                    RD.SetBool("Open", false);
                    LD.SetBool("Closed", true);
                    RD.SetBool("Closed", true);

                    IsDoorOpen = false;
                    EnterTrigger = false;

                    DoorState = 0;

                }


                OpenDoorSound.Play();

            }
    }

    IEnumerator LightTimer()
    {
        if (IsDoorOpen == true)
        {
            yield return new WaitForSeconds(2.5f);
            OpenLight.SetActive(true);
            ClosedLight.SetActive(false);
        }

        if (IsDoorOpen == false)
        {
            yield return new WaitForSeconds(2.5f);
            OpenLight.SetActive(false);
            ClosedLight.SetActive(true);
        }
    }

    IEnumerator CutSceneTimer()
    {
        if (IsDoorOpen == true)
        {
           
            CutcutsceneCam.SetActive(true);
            NormalCam.SetActive(false);
            yield return new WaitForSeconds(2.5f);
            CutcutsceneCam.SetActive(false);
            NormalCam.SetActive(true);

        }

        if (IsDoorOpen == false)
        {

            CutcutsceneCam.SetActive(true);
            NormalCam.SetActive(false);
            yield return new WaitForSeconds(2.5f);
            CutcutsceneCam.SetActive(false);
            NormalCam.SetActive(true);

        }
    }

}