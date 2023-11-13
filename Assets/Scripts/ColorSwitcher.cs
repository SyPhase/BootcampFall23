using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorSwitcher : MonoBehaviour
{
    [SerializeField] List<Color> _playerColors = new List<Color>();

    void Start()
    {
        int playerID = (int)GetComponent<PlayerInput>().user.id - 1;

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        while (playerID >= _playerColors.Count)
        {
            playerID -= _playerColors.Count;
        }

        meshRenderer.material.color = _playerColors[playerID];
    }
}