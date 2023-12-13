using UnityEngine;
using TMPro;

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
    private float verticalVelocity; // Adjusted for smooth jumping
    private bool isRunning;

    public TextMeshProUGUI speedText; // Assign this in the inspector

    // Start is called before the first frame update
    void Start()
    {
        gravity = -18f; // Set to a negative value for downward gravity
        verticalVelocity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Check whether the player is running
        isRunning = Input.GetKey(KeyCode.LeftShift);

        float currentSpeed = isRunning ? runningSpeed : walkingSpeed;
        xMove = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        zMove = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        move = transform.right * xMove + transform.forward * zMove;

        if (characterController.isGrounded)
        {
            // Apply gravity while the player is grounded
            verticalVelocity = Mathf.MoveTowards(verticalVelocity, gravity, Time.deltaTime * jumpSpeed);

            if (Input.GetButtonDown("Jump"))
            {
                // Jump if the player is grounded
                verticalVelocity = jumpSpeed;
            }
        }
        else
        {
            // Keep applying gravity while airborne
            verticalVelocity += gravity * Time.deltaTime;
        }

        move.y = verticalVelocity * Time.deltaTime;

        characterController.Move(move);

        // Display speed in the TextMeshProUGUI component
        float currentMagnitude = new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;
        speedText.text = "Speed: " + Round(currentMagnitude, 1);
    }

    // Helper function to round a float value
    private static float Round(float value, int digits)
    {
        float mult = Mathf.Pow(10.0f, (float)digits);
        return Mathf.Round(value * mult) / mult;
    }
}
