using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void MyInput(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer(){
        moveDirection = (orientation.forward * verticalInput) + (orientation.right * horizontalInput);
        rb.AddForce(moveDirection.normalized * speed * 5f, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void FixedUpdate(){
        MovePlayer();
    }
}
