using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCam : MonoBehaviour
{

	public float rotationSpeed;

	float rotX, rotY;

	public Transform player;


	//Called on the first frame
	void Start(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = true;
	}

	void Update(){
		float mousey= Input.GetAxis("Mouse Y") * rotationSpeed * 0.1f;
		float mousex= Input.GetAxis("Mouse X") * rotationSpeed * 0.1f;
		
		rotX -= mousey;
		rotY += mousex;

		rotX = Mathf.Clamp(rotX, -80, 80);

        Quaternion lastRot = Quaternion.Euler(rotX, rotY, 0);

        transform.rotation = lastRot;

        player.rotation = Quaternion.Euler(0, rotY, 0);
    }

}
