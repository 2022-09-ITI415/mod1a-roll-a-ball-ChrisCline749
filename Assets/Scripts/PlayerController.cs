using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;

    private Rigidbody rb;
    private float moveX;
    private float moveY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        moveX = movementVector.x;
        moveY = movementVector.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp") == true)
        {
            other.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);

        rb.AddForce(movement * speed);
    }
}
