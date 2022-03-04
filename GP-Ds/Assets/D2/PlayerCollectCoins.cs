using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollectCoins : MonoBehaviour
{

    public int RDCounter = 0;
    public Text RDTextUI;

    public void RDvoid()
    {
      RDTextUI.text = "Raise dead: " + RDCounter;
    }


}
