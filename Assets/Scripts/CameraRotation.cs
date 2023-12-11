using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 200f;

    private float xMouse;
    private float yMouse;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleRotationInput();
        ApplyRotation();
    }

    void HandleRotationInput()
    {
        xMouse = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        yMouse = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        // Calculation rotation
        xRotation -= yMouse;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }

    void ApplyRotation()
    {
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * xMouse);
    }
}
