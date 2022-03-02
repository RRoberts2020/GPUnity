using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollection : MonoBehaviour
{
    private int Stars;

    // Start is called before the first frame update
    void Start()
    {
        Stars = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("You have: " + Stars + " Stars");
        }

    }

    private void OnTriggerEnter(Collider Star)
    {
       if(Star.gameObject.tag== "Stars")
        {
            Stars++;
            Star.gameObject.SetActive(false);
        }

    }
}
