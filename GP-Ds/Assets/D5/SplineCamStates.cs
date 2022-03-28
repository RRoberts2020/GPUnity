using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class SplineCamStates : MonoBehaviour
{
    public GameObject splineCam;
    public GameObject normalCam;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            splineCam.SetActive(true);
            normalCam.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            splineCam.SetActive(false);
            normalCam.SetActive(true);
        }
    }
}