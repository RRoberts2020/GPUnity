using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private int coins;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("You have: " + coins + " coins");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag=="Coin")
        {
            coins++;
            other.gameObject.SetActive(false);
        }

    }
}
