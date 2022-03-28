using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class SplineCamStates : MonoBehaviour
{
    public GameObject splineCam;
    public GameObject normalCam;

    public bool enterTrigger;


    void Start()
    {
        enterTrigger = false;

    }

    void Update()
    {

        if (enterTrigger == true)
        {
            splineCam.SetActive(true);
            normalCam.SetActive(false);

        }
        else if (enterTrigger == false)
        {
            splineCam.SetActive(false);
            normalCam.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enterTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enterTrigger = false;
        }
    }
}