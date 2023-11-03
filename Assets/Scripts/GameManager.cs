using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    // Input
    InputActionMap _playerActionMap;

    void Awake()
    {
        // Input
        _playerActionMap = FindObjectOfType<PlayerInput>().actions.FindActionMap("Player");
    }

    void OnEnable()
    {
        // Input
        _playerActionMap.FindAction("Quit").started += HandleQuit;
        _playerActionMap.Enable();
    }

    void OnDisable()
    {
        // Input
        _playerActionMap.FindAction("Quit").started -= HandleQuit;
        _playerActionMap.Disable();
    }

    private void HandleQuit(InputAction.CallbackContext obj)
    {
        Application.Quit();
        print("ERROR: User tried to Quit!");
    }
}