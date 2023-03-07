using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCam : MonoBehaviour
{

	public float rotationSpeed;

	float rotX, rotY;

	//Called on the first frame
	void Start(){
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = true;
	}

	void Update(){
		float mousey= Input.GetAxis("Mouse Y");
		float mousex= Input.GetAxis("Mouse X");
		
		rotX += mousey * rotationSpeed * 0.1f;
		rotY += mousex * rotationSpeed * 0.1f;

		rotX = Mathf.Clamp(rotX, -80, 80);

		Quaternion localRotation = Quaternion.Euler(-rotX, rotY, 0.0f);
		transform.rotation = localRotation;
	}

}
