using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f, jumpSpeed = 10f;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask mask;

    public bool isGrounded, isJumping;

    Rigidbody rb;
    Vector3 velocity, move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {



        float horizontal = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float vertical = Input.GetAxisRaw("Vertical") * moveSpeed;

		move = transform.right * horizontal + transform.up * rb.velocity.y + transform.forward * vertical;

		if (isGrounded){

			if (Input.GetKeyDown(KeyCode.Space) && !isJumping){
				move.y = jumpSpeed;
				isJumping = true;
			}
		}

        velocity = new Vector3(move.x, move.y, move.z);
        rb.velocity = velocity;
    }

	void FixedUpdate(){
		if (Physics.CheckSphere(groundCheck.position, groundDistance, mask)){
			isJumping = false;
			isGrounded = true;
		}
	}


}
