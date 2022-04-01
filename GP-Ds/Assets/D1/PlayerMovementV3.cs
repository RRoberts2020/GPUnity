using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using PathCreation;

public class PlayerMovementV3 : MonoBehaviour
{

    public GameObject player;
    
    PlayerGamepadInput PlayerController;
    CharacterController InnerCharacterController;
    Animator anim;

    Vector2 currentMovementInput;
    Vector3 currentWalkMovement;
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

    //Spline path

    public PathCreator pathCreator;
    public EndOfPathInstruction end; // What will happen if the end of path is reached
    float dstTravelled;

    public Quaternion setPlayerSplineRotation;

    bool playerSpline;

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

        setPlayerSplineRotation = transform.rotation;
    }


    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentWalkMovement.x = currentMovementInput.x;
        currentWalkMovement.z = currentMovementInput.y;
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

    void OnInteract()
    {

            if (Input.GetButtonDown("Interact"))
            {
                anim.SetBool("isInteract", true);
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
            anim.SetBool("isInteract", false);

        }
        //If I don't want to walk
        else if (!isMovementPressed && isWalking)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isInteract", false);
        }
        //If I want to run
        if (isMovementPressed && !isRunning && isRunPressed)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isInteract", false);
        }
        //If I don't want to run
        else if (!isMovementPressed || !isRunning || !isRunPressed)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isInteract", false);

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
            localapplyedmovement = transform.TransformDirection(currentWalkMovement);
        }

        InnerCharacterController.Move(localapplyedmovement * Time.deltaTime);

        OnJump();

        OnInteract();

       

        if (playerSpline == true)
        {

            transform.rotation = setPlayerSplineRotation;

            //Z and y axis
            dstTravelled = currentWalkMovement.z = currentMovementInput.y;
            dstTravelled = currentRunMovement.z = currentMovementInput.y * 7.5f;

            //X axis
            currentWalkMovement.x = currentMovementInput.x * 0.0f;
            currentRunMovement.x = currentMovementInput.x * 0.0f;
            OnJump();
        }

    }

    void OnEnable()
    {
        PlayerController.CharacterControls.Enable();
    }

    void OnDisable()
    {
        PlayerController.CharacterControls.Disable();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spline"))
        {
            playerSpline = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spline"))
        {
            playerSpline = false;
        }
    }
}
