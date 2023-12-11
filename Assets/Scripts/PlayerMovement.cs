using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded;
    private bool readyToJump = true;
    private bool exitingSlope = false;

    public TextMeshProUGUI text_speed;
    public TextMeshProUGUI text_mode;

    public float maxSlopeAngle = 50f;
    public float playerHeight = 2f;

    public enum State { Ground, Air }
    public State state = State.Ground;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Ensure rotations are frozen
        rb.useGravity = false; // Disable gravity initially
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundMask);

        if (isGrounded && exitingSlope)
        {
            exitingSlope = false;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        if (isGrounded && !exitingSlope)
        {
            state = State.Ground;
            JumpCheck();
        }
        else
        {
            state = State.Air;
        }

        Vector3 force = moveDirection * speed;

        // Apply gravity only when in the air
        if (!isGrounded)
        {
            force.y += gravity;
        }

        rb.AddForce(force);

        TextStuff();
    }

    private void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        exitingSlope = true;

        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    }

    private void TextStuff()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (state == State.Ground)
            text_speed.SetText("Speed: " + Round(rb.velocity.magnitude, 1) + " / " + Round(speed, 1));
        else
            text_speed.SetText("Speed: " + Round(flatVel.magnitude, 1) + " / " + Round(speed, 1));

        text_mode.SetText(state.ToString());
    }

    public static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }

    void OnCollisionStay(Collision collision)
    {
        if (isGrounded)
        {
            // Align player's up direction with the normal of the ground
            transform.up = collision.contacts[0].normal;
        }
    }
}
