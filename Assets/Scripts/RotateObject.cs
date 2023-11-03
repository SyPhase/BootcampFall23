using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 5f;

    void FixedUpdate()
    {
        transform.Rotate(0f, _rotationSpeed, 0f);
    }
}