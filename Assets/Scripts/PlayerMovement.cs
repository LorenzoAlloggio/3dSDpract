using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkingSpeed;
    public float runningSpeed;
    public float gravity;
    public float jumpSpeed;

    public CharacterController characterController;

    private float xMove;
    private float zMove;
    private Vector3 move;
    private bool isJumping;
    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        gravity = -9.81f; // Set to a negative value for downward gravity
    }

    // Update is called once per frame
    void Update()
    {

        isRunning = Input.GetKey(KeyCode.LeftShift);


        float currentSpeed = isRunning ? runningSpeed : walkingSpeed;

        xMove = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        zMove = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;

        move = transform.right * xMove + transform.forward * zMove;



        if (characterController.isGrounded)
        {
            // Apply gravity only when the character is grounded
            move.y = gravity * Time.deltaTime;

            if (Input.GetButtonDown("Jump"))
            {
                // Jump only if the jump button is pressed and the character is grounded
                move.y = jumpSpeed;
            }
        }
        else
        {
            // Apply gravity continuously when the character is in the air
            move.y += gravity * Time.deltaTime;
        }

        characterController.Move(move);
    }
}
