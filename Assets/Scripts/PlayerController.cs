using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] Camera MainCam;
    [SerializeField] float speed = 10;

    Rigidbody rb;
    float movementX;
    float movementY;

  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();  //Read inputs from controls
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        float cameraRot = MainCam.transform.rotation.eulerAngles.y;
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); //Put the movement into a Vector3, keep Vertical at zero
        movement = movement.normalized; //Take the magnitude out of the vector, this leaves us with just the direction. (fixes your movement so moving diagonal doesn't make you go faster than normal)
        rb.AddForce(Quaternion.Euler(0, cameraRot, 0) * movement * speed); //Apply force in movement direction relative to the camera
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
              
    }
}