using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject InteractiveLight;
    private bool On = false; 

    private void OnTriggerStay(Collider Player)
    {
        if (Player.tag == "Player" && Input.GetKeyDown(KeyCode.G) && !On)
        {
            InteractiveLight.SetActive(true);
            On = true;
            Debug.Log("Light on");
        }
        else if (Player.tag == "Player" && Input.GetKeyDown(KeyCode.H) && !On)
        {
            InteractiveLight.SetActive(false);
            On = false;
            Debug.Log("Light off");
        }
    }
}
