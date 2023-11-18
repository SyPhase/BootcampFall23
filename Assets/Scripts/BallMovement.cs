using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class BallMovement : MonoBehaviour
{
    // SerializeField allows the variable to be set in the Unity Editor while keeping the variable private
    // Sets the player's speed factor
    [SerializeField] float _speed = 10f;
    // Sets the player's jump force factor
    [SerializeField] float _jumpForce = 500f;

    // Drag in the audio clip to play when jumping
    [SerializeField] AudioClip _jumpSFX;

    // Volume between 0 and 1
    [Range(0f, 1f)]
    [SerializeField] float _jumpVolume = 1f;

    // Drag in the audio clip to play when hitting surfaces
    [SerializeField] AudioClip _hitSFX;

    // Volume between 0 and 1
    [Range(0f, 1f)]
    [SerializeField] float _hitVolume = 1f;

    // private variable to store "Ground" objects currently in contact with
    int _touchingGround = 0;

    // Cache the Rigidbody as a variable since we will use it each frame
    Rigidbody _rigidBody;

    // Cache PointSystem object to track points
    PointSystem _pointSystem;

    // Cache the camera
    Camera _mainCam;

    // Cache Sound Manager's AudioSource
    AudioSource _soundManager;

    //// Input Variables ////
    // Player Input is a component on the player object
    PlayerInput _playerInput;

    // This Input Action Map is the "Player" map, but can be "UI" or any other map you set in the Input Actions Asset
    InputActionMap _playerActionMap;

    // Input Action is one specific action in the input map, for example "Movement", "Jump", or "Quit"
    InputAction _movementAction;


    // Unity Function, called when the object is loaded into the scene
    void Awake()
    {
        // Initialize the Input variables
        _playerInput = GetComponent<PlayerInput>();
        _playerActionMap = _playerInput.actions.FindActionMap("Player");

        // This stores a reference to the Rigidbody on this ball to be used as a variable later
        _rigidBody = GetComponent<Rigidbody>();

        // This stores a reference to the PointSystem component 
        _pointSystem = FindObjectOfType<PointSystem>();

        // This stores a reference to the camera
        _mainCam = FindObjectOfType<Camera>();

        _soundManager = FindObjectOfType<AudioSource>();
    }

    void OnEnable()
    {
        // Activates our Input when enabled (important this has to be done OnEnable)
        _movementAction = _playerActionMap.FindAction("Movement");
        // This syntax "subscribes" the HandleJump function to the "Jump" Action
        _playerActionMap.FindAction("Jump").started += HandleJump;
        _playerActionMap.Enable();

        transform.position = FindObjectOfType<SpawnPoint>().transform.position;
    }

    void OnDisable()
    {
        // Deactivates our Input when disabled (important this has to be done OnDisable)
        _playerActionMap.FindAction("Jump").started -= HandleJump;
        _playerActionMap.Disable();
    }

    // This function will be called whenever this Player presses the "Jump" Action
    private void HandleJump(InputAction.CallbackContext obj)
    {
        // Do nothing if not touching the ground
        if (_touchingGround < 1) { return; }

        // Adds upward force to jump
        _rigidBody.AddForce(0f, _jumpForce, 0f);

        // Play jump sound at set jump volume
        _soundManager.PlayOneShot(_jumpSFX, _jumpVolume);
    }

    // This is called for each physics step (a.k.a. every 0.02 seconds to keep the timescale constant for physics interactions)
    void FixedUpdate()
    {
        // We need to take the input from the user (keyboard, controller, ...)
        // define variables to store this information
        // Cache movement action values
        float horizontalMovement = _movementAction.ReadValue<Vector2>().x;
        float verticalMovement = _movementAction.ReadValue<Vector2>().y;

        // Since we are dealing with 3D space, we will align horizontal movement to the x-axis
        // and vertical to the z-axis
        //Vector3 moveBall = new Vector3(horizontalMovement, 0, verticalMovement);

        // Lastly, we will need to access the physics component of the ball (Rigidbody)
        //_rigidBody.AddForce(moveBall * _speed);

        //// Advanced camera controls ////
        // Get the camera's y rotation angle
        float cameraRot = _mainCam.transform.rotation.eulerAngles.y;

        //Put the movement into a Vector3, keep Vertical at zero
        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);

        //Take the magnitude out of the vector, this leaves us with just the direction. (fixes your movement so moving diagonal doesn't make you go faster than normal)
        movement = movement.normalized;

        //Apply force in movement direction relative to the camera
        _rigidBody.AddForce(Quaternion.Euler(0, cameraRot, 0) * movement * _speed);
    }

    // This is called when this objects collider touches another object's collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            _pointSystem.AddPoint();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _touchingGround++;
        }

        if (collision.impulse.magnitude > 4f)
        {
            _soundManager.PlayOneShot(_hitSFX, _hitVolume);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _touchingGround--;
        }
    }
}