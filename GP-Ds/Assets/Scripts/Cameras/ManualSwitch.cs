using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualSwitch : MonoBehaviour
{
    public GameObject PlayerCam1;
    public GameObject PlayerCam2;
    public GameObject PlayerCam3;


    void Update()
    {
        if(Input.GetButtonDown("PlayerCam1"))
        {
            PlayerCam1.SetActive(true);
            PlayerCam2.SetActive(false);
            PlayerCam3.SetActive(false);
        }

        if (Input.GetButtonDown("PlayerCam2"))
        {
            PlayerCam1.SetActive(false);
            PlayerCam2.SetActive(true);
            PlayerCam3.SetActive(false);
        }
        if (Input.GetButtonDown("PlayerCam3"))
        {
            PlayerCam1.SetActive(false);
            PlayerCam2.SetActive(false);
            PlayerCam3.SetActive(true);
        }
    }
}
