using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScript : MonoBehaviour
{
    //// Global variables for THIS script
    [SerializeField] float movementSpeed = 10f;

    int lives = 3;

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        // local variables in this method
        float mass = rigidbody.mass;

        movementSpeed = movementSpeed * mass;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.AddForce(movementSpeed, 0f, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.impulse);
    }

    private void OnCollisionExit(Collision collision)
    {
        print(collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
    }
}
