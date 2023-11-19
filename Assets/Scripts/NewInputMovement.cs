using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputMovement : MonoBehaviour
{
    // Adjustable in the Inspector tab
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] float jumpForce = 10f;

    // Cache rigidbody for movement
    Rigidbody rigidbody;

    // Cache Input
    InputActionMap playerActionMap;
    InputAction movementAction;

    // Cache Input Values
    float xAxis = 0f;
    float yAxis = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        playerActionMap = GetComponent<PlayerInput>().actions.FindActionMap("Player");
        movementAction = playerActionMap.FindAction("Movement");

        playerActionMap.FindAction("Jump").started += HandleJump;
        playerActionMap.Enable();
    }

    void HandleJump(InputAction.CallbackContext obj)
    {
        // Add upward force to jump
        rigidbody.AddForce(0f, jumpForce, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        // Cache movement action values
        xAxis = movementAction.ReadValue<Vector2>().x;
        yAxis = movementAction.ReadValue<Vector2>().y;

        if (Keyboard.current[Key.Escape].wasPressedThisFrame)
        {
            // Quit Game
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        // Add force in the x and z direction for 3D (x and y for 2D)
        rigidbody.AddForce(xAxis * movementSpeed, 0f, yAxis * movementSpeed);
    }
}
