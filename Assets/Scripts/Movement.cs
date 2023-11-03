using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] float _speed = 10f;

    Rigidbody _rigidBody;

    // Input
    PlayerInput _playerInput;
    InputActionAsset _inputActionAsset;
    InputActionMap _playerActionMap;
    InputAction _movementAction;

    float _movementValue = 0f;

    void Awake()
    {
        // Input
        _playerInput = GetComponent<PlayerInput>();
        _inputActionAsset = _playerInput.actions;
        _playerActionMap = _inputActionAsset.FindActionMap("Player");

        // This stores the Rigidbody on this ball to be used as a variable later
        _rigidBody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        // Input
        _movementAction = _playerActionMap.FindAction("Movement");
        _playerActionMap.FindAction("Jump").started += HandleJump;
        _playerActionMap.Enable();
    }

    void OnDisable()
    {
        // Input
        _playerActionMap.FindAction("Jump").started -= HandleJump;
        _playerActionMap.Disable();
    }

    private void HandleJump(InputAction.CallbackContext obj)
    {
        // TODO: Jump Logic Here
    }

    void FixedUpdate()
    {
        // We need to take the input from the user (keyboard, controller, ...)
        // define variables to store this information
        // Cache movement action values
        float horizontalMovement = _movementAction.ReadValue<Vector2>().x;
        float verticalMovement = _movementAction.ReadValue<Vector2>().y;

        // Since we are dealing with 3D space, we will align horizontal movement to the x-axis
        // and vertical to the z-axis
        Vector3 moveBall = new Vector3(horizontalMovement, 0, verticalMovement);

        // Lastly, we will need to access the physics component of the ball (Rigidbody)
        _rigidBody.AddForce(moveBall * _speed);
    }
}