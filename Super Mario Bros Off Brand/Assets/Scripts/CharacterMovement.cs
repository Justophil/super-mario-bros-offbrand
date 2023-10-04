using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Controllers:
    W: Forward
    S: Backward
    A: Left
    D: Right
    Left Shift: Run
    Left Alt: Enable/Disable Cursor
    Space: Jump/Double Jump
*/

public class CharacterMovement : MonoBehaviour
{

   public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public bool cursorActive = true;
    public float mouseSensitivity = 5.0f;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private float walkSpeed = 5;
    private float runSpeed = 8; 
    private CharacterController controller;
    private Animator animator;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        GameManager.PrintScore();
    }
    public void Update() {
        UpdateCursor();
        UpdateRotation();
        ProcessMovement();
    }
    public void LateUpdate()
    {
       UpdateAnimator();  
    }
    void DisableRootMotion()
    {
        animator.applyRootMotion = false;  
    }
    void UpdateRotation()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X")* mouseSensitivity, 0, Space.Self);
 
    }
    void UpdateCursor() {
        if(Input.GetButton("VisibleCursor")){
            cursorActive = !cursorActive;
            Invoke("SetCursor",0.15f);
        }
    }
    void SetCursor() {
        UnityEngine.Cursor.visible = cursorActive;
        UnityEngine.Cursor.lockState = (cursorActive) ? CursorLockMode.None : CursorLockMode.Locked;
    }
    void UpdateAnimator()
    {
        groundedPlayer = controller.isGrounded; 
        Vector3 characterXandZMotion = new Vector3(playerVelocity.x,0,playerVelocity.z);
        if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0 || Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            if(Input.GetButton("Run")) {
                animator.SetFloat("Speed", 1.0f);
            }
            else {
                animator.SetFloat("Speed", 0.5f);
            }
        }
        else {
            animator.SetFloat("Speed",0.0f);
        }
        animator.SetBool("IsGrounded",groundedPlayer);
    }

    void ProcessMovement()
    { 
        // Moving the character foward according to the speed
        float speed = GetMovementSpeed();
 
        // Get the camera's forward and right vectors
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
 
        // Make sure to flatten the vectors so that they don't contain any vertical component
        cameraForward.y = 0;
        cameraRight.y = 0;
 
        // Normalize the vectors to ensure consistent speed in all directions
        cameraForward.Normalize();
        cameraRight.Normalize();
 
        // Calculate the movement direction based on input and camera orientation
        Vector3 moveDirection = (cameraForward * Input.GetAxis("Vertical")) + (cameraRight * Input.GetAxis("Horizontal"));
 
        // Apply the movement direction and speed
        Vector3 movement = moveDirection.normalized * speed * Time.deltaTime;
 
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
        {
            if (Input.GetButtonDown("Jump"))
            {
                gravity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                animator.SetFloat("Jump",1.0f);
            }
            else
            {
                // Dont apply gravity if grounded and not jumping
                gravity.y = -1.0f;
                animator.SetFloat("Jump",0.0f);
            }
        }
        else
        {
            if(Input.GetButtonDown("Jump") && GameManager.is2Jumpable) {
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                animator.SetFloat("Jump",2.0f);
                GameManager.is2Jumpable = false;
            }
            else {
                animator.SetFloat("Jump",0.0f);
                gravity.y += gravityValue * Time.deltaTime;
            }
        }
        // Apply gravity and move the character
        playerVelocity = gravity * Time.deltaTime + movement;
        controller.Move(playerVelocity);

    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Run"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }
}
