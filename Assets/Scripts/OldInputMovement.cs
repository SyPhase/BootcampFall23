using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldInputMovement : MonoBehaviour
{
    // Adjustable in the Inspector tab
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float jumpForce = 10f;

    // Cache rigidbody for movement
    Rigidbody rigidbody;

    // Cached input values
    float xAxis = 0f;
    float yAxis = 0f;
    float jumpAxis = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get Rigidbody
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input values each frame
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");
        jumpAxis = Input.GetAxis("Jump");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Quit Game
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        // Add force in the x and z direction for 3D (x and y for 2D)
        rigidbody.AddForce(xAxis * movementSpeed, 0f, yAxis * movementSpeed);

        // Add upward force to jump
        rigidbody.AddForce(0f, jumpAxis * jumpForce, 0f);
    }
}
