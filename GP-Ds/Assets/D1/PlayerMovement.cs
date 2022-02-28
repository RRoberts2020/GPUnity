using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    //Player movement
    private float MovingSpeed = 6;
    private float RotationSpeed = 90;
    private float GravityForce = -20;
    private float JumpSpeed = 15;

    Vector3 MoveVelocity;
    Vector3 TurningVelocity;

    CharacterController Player;

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
