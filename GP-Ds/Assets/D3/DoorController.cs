using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    PlayerGamepadInput PlayerController;
    CharacterController InnerCharacterController;
    Animator anim;

    public AudioSource OpenDoorSound;
    public GameObject LeftDoor;
    public Animator LD;
    public Animator RD;
    public GameObject RightDoor;
    public bool EnterTrigger;
    public bool ButtonToOepen;
    public bool DoorIsOpen;

    static int active;


    void Start()
    {
        active = 0;


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
        }

        //if (EnterTrigger == true)
        //{

        //}

        //if (ButtonToOepen == true)
        //{

        //}

        //if (DoorIsOpen == true)
        //{
        //    anim.SetBool("Open", true);
        //}
        //else if (DoorIsOpen == false)
        //{
        //    anim.SetBool("Closed", true);
        //}
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
        if (Input.GetButtonDown("Submit"))
        {
            active++;

            if (active == 1)
            {
                LD.SetBool("Open", true);
                RD.SetBool("Open", true);
                LD.SetBool("Closed", false);
                RD.SetBool("Closed", false);

            }

            if (active == 2)
            {
                LD.SetBool("Open", false);
                RD.SetBool("Open", false);
                LD.SetBool("Closed", true);
                RD.SetBool("Closed", true);

                active = 0;

            }


        }

    }
    //OpenDoorSound.Play();
}