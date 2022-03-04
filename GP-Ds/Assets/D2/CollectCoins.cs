using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{

    public AudioSource CollectSound;


    private void OnTriggerEnter(Collider Stars)
    {
        if(Stars.CompareTag("Player"))
        {
            PlayerCollectCoins pcc = Stars.GetComponent<PlayerCollectCoins>();
            CollectSound.Play();
            pcc.RDCounter++;
            pcc.RDvoid();
            Destroy(gameObject);

        }
    }


 

}
