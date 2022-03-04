using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementV2 : MonoBehaviour
{




    //Player movement
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;

    private Vector3 MoveDircection;
    private Vector3 Velocity;

    [SerializeField] private bool IsPlayerGrounded;
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private float Gravity;

    [SerializeField] private float JumpHeight;

    CharacterController Player;

    //Player animation
    private Animator anim;


    private void Start()
    {

        Player = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {
        IsPlayerGrounded = Physics.CheckSphere(transform.position, GroundCheckDistance, GroundMask);

        if(IsPlayerGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }


        float MoveZ = Input.GetAxis("Vertical");


        MoveDircection = new Vector3(0, 0, MoveZ);
        MoveDircection = transform.TransformDirection(MoveDircection);

        if(IsPlayerGrounded)
        {
            //Idle, Walk and Run check
            if (MoveDircection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift)) //!Input.GetButtonDown("Run"))
            {
                //Walking check
                Walk();
                //Debug.Log("You are walking");
            }
            else if (MoveDircection != Vector3.zero && Input.GetKey(KeyCode.LeftShift)) //Input.GetButtonDown("Run"))
            {
                //Running check
                Run();
                //Debug.Log("You are Running");

            }
            else if (MoveDircection == Vector3.zero)
            {
                //Idle check
                Idle();
                //Debug.Log("You are Idle");
            }

            MoveDircection *= MoveSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }

        }        

        Player.Move(MoveDircection * Time.deltaTime);

        Velocity.y += Gravity * Time.deltaTime;
        Player.Move(Velocity * Time.deltaTime);

    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0);
    }

    private void Walk()
    {
        MoveSpeed = WalkSpeed;

        anim.SetFloat("Speed", 0.5f);
    }

    private void Run()
    {
        MoveSpeed = RunSpeed;
        anim.SetFloat("Speed", 1);
    }

    private void Jump()
    {
        Velocity.y = Mathf.Sqrt(JumpHeight * -2 * Gravity);
    }



}
