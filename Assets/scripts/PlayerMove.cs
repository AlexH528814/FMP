using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f, jumpForce = 10f, gravity;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask mask1;

    public bool isGrounded;

    Rigidbody rb;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(groundCheck.position, groundDistance, mask1))
            isGrounded = true;
        else isGrounded = false;



        float downspeed = -gravity;

        if (isGrounded)
        {
            downspeed = 0f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float vertical = Input.GetAxisRaw("Vertical") * moveSpeed;

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        velocity = new Vector3(move.x, downspeed, move.z);

        rb.velocity= velocity;

        Debug.Log(rb.velocity);
        
    }
}
