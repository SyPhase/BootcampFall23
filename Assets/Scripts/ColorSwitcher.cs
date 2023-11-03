using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class ColorSwitcher : MonoBehaviour
{
    //[SerializeField] Material _player1;
    //[SerializeField] Material _player2;
    //[SerializeField] Material _player3;
    //[SerializeField] Material _player4;

    void Start()
    {
        //uint playerID = GetComponent<PlayerInput>().user.id;

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}