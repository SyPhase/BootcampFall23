using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public Camera MainCam;
  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
     }


    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();  //Read inputs from controls
        movementX = movementVector.x;
        movementY = movementVector.y;
    }


    private void FixedUpdate()
    {
        float cameraRot = MainCam.transform.rotation.eulerAngles.y;
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);//Put the movement into a Vector3, keep Vertical at zero
        movement = movement.normalized;//Take the magnitude out of the vector, this leaves us with just the direction. (fixes your movement so moving diagonal doesn't make you go faster than normal)
        rb.AddForce(Quaternion.Euler(0, cameraRot, 0) * movement * speed);//Apply force in movement direction relative to the camera
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
         }
              
    }
}