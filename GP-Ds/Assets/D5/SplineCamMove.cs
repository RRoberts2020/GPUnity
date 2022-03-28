using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SplineCamMove : MonoBehaviour
{

    public GameObject splineCam;
    public GameObject targetOjbect;

    public PathCreator pathCreator;
    public EndOfPathInstruction end; // What will happen if the end of path is reached
    public float speed; // Speed of game object
    float dstTravelled;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dstTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(dstTravelled, end);
        splineCam.transform.LookAt(targetOjbect.transform);
    }
}
