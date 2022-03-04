using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollectCoins : MonoBehaviour
{

    public int RDCounter = 0;
    public Text RDTextUI;
    public GameObject SpawnUndeadTroop;

    public void RDvoid()
    {
        RDTextUI.text = "Collect undead power: " + RDCounter;
        if (RDCounter == 5)
        {
            RDTextUI.text = "You can now the raise" +
                " undead troops to fight for you";
        }
    }

    public void Update()
    {
        if (Input.GetButtonDown("RaiseDead") && RDCounter == 5)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 10), 5, Random.Range(-10, 10));
            Instantiate(SpawnUndeadTroop, randomSpawnPosition, Quaternion.identity);
        }
    }
}
