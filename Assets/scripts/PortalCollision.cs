using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision){
    
	if (collision.gameObject.tag == "Portal") {gameObject.SetActive(false); globals.lastPortal.SetActive(true);}

    }
}
