using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    
    public float MovingSpeed = 6;
    public float RotationSpeed = 90;
    public float GravityForce = -20f;
    public float JumpSpeed = 15;

    CharacterController Player;
    Vector3 MoveVelocity;
    Vector3 TurningVelocity;

    void Awake()
    {
        Player = GetComponent<CharacterController>();
    }

    void Update()
    {
        var Horizontal = Input.GetAxis("Horizontal");
        var Vertical = Input.GetAxis("Vertical");

        if(Player.isGrounded)
        {
            MoveVelocity = transform.forward * MovingSpeed * Vertical;
            TurningVelocity = transform.up * RotationSpeed * Horizontal;

            if (Input.GetButtonDown("Jump"))
            {
                MoveVelocity.y = JumpSpeed;
            }
        }
        MoveVelocity.y += GravityForce * Time.deltaTime;
        Player.Move(MoveVelocity * Time.deltaTime);
        transform.Rotate(TurningVelocity * Time.deltaTime);
    }
}
