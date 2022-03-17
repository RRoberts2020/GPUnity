using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnEnemy : MonoBehaviour
{
    public bool EnterTrigger;
    public GameObject FocusCam;
    public GameObject NormalCam;


    static int FocusState;


    void Start()
    {
        FocusState = 0;
        NormalCam.SetActive(true);
        FocusCam.SetActive(false);

    }

    void Update()
    {
        if (EnterTrigger)
        {
            FocusActive();

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
            NormalCam.SetActive(true);
            FocusCam.SetActive(false);

        }
    }

    void FocusActive()
    {

        if (Input.GetButtonDown("Focus") && EnterTrigger == true)
        {
            FocusState++;

            if (FocusState == 1)
            {

                NormalCam.SetActive(false);
                FocusCam.SetActive(true);

            }

            if (FocusState == 2)
            {

                NormalCam.SetActive(true);
                FocusCam.SetActive(false);

                FocusState = 0;

            }
        }
    }
}