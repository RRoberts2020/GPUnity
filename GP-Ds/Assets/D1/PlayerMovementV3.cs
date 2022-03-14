using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementV3 : MonoBehaviour
{
    
    PlayerGamepadInput PlayerController;
    CharacterController InnerCharacterController;
    Animator anim;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    Vector3 localapplyedmovement;
    bool isMovementPressed;
    bool isRunPressed;

    //Jumping
    private Vector3 JumpVelocity;

    [SerializeField] private bool IsPlayerGrounded;
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private float Gravity;
    [SerializeField] private float JumpHeight;

    void Awake()
    {
        PlayerController = new PlayerGamepadInput();
        InnerCharacterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

       // PlayerController.CharacterControls.Move.started += onMovementInput;
        PlayerController.CharacterControls.Move.performed += OnMovementInput;
        PlayerController.CharacterControls.Move.canceled += OnMovementInput;
        PlayerController.CharacterControls.Run.started += OnRun;
        PlayerController.CharacterControls.Run.canceled += OnRun;

    }


    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        currentRunMovement.x = currentMovementInput.x * 7.5f;
        currentRunMovement.z = currentMovementInput.y * 7.5f;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }


    void OnRun (InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }
        
    void OnJump()
    {
        IsPlayerGrounded = Physics.CheckSphere(transform.position, GroundCheckDistance, GroundMask);

        if (IsPlayerGrounded && JumpVelocity.y < 0)
        {
            JumpVelocity.y = -2f;
        }


        if (IsPlayerGrounded)
        {

            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("isJumping", true);
                Jump();
               
            }

        }

        JumpVelocity.y += Gravity * Time.deltaTime;
        InnerCharacterController.Move(JumpVelocity * Time.deltaTime);

    }

    private void Jump()
    {
        JumpVelocity.y = Mathf.Sqrt(JumpHeight * -2 * Gravity);

    }

    void OnLeftAttack()
    {

            if (Input.GetButtonDown("LeftAttack"))
            {
                anim.SetBool("isLeftAttack", true);
                Debug.Log("Left Attack triggered");
            }
    }



    void HandleAnimation()
    {
       bool isWalking = anim.GetBool("isWalking");
       bool isRunning = anim.GetBool("isRunning");

        //If I want to walk
        if (isMovementPressed && !isWalking)
        {
            anim.SetBool("isWalking", true);
            anim.SetBool("isLeftAttack", false);

        }
        //If I don't want to walk
        else if (!isMovementPressed && isWalking)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isLeftAttack", false);
        }
        //If I want to run
        if (isMovementPressed && !isRunning && isRunPressed)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isLeftAttack", false);
        }
        //If I don't want to run
        else if (!isMovementPressed || !isRunning || !isRunPressed)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isLeftAttack", false);

        }

    }

    void Update()
    {
        HandleAnimation();

        if (isRunPressed)
        {
            localapplyedmovement = transform.TransformDirection(currentRunMovement);
        }
        else
        {
            localapplyedmovement = transform.TransformDirection(currentMovement);
        }

        InnerCharacterController.Move(localapplyedmovement * Time.deltaTime);

        OnJump();

        OnLeftAttack();

    }

    void OnEnable()
    {
        PlayerController.CharacterControls.Enable();
    }

    void OnDisable()
    {
        PlayerController.CharacterControls.Disable();
    }
}
