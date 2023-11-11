using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        _playerActionMap.FindAction("Restart").started += HandleRestart;
        _playerActionMap.Enable();
    }

    void OnDisable()
    {
        // Input
        _playerActionMap.FindAction("Quit").started -= HandleQuit;
        _playerActionMap.FindAction("Restart").started -= HandleRestart;
        _playerActionMap.Disable();
    }

    // Quits the game
    private void HandleQuit(InputAction.CallbackContext obj)
    {
        Application.Quit();
        print("ERROR: User tried to Quit!");
    }

    // Restarts current level
    private void HandleRestart(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}