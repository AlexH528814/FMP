using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPortals : MonoBehaviour
{
	public GameObject blueportal;
	public GameObject orangeportal;
	public int maxPortals = 1;

	Camera cam;
	public Transform player;

	// Start is called before the first frame update
    void Start()
    {
	    cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
	    player.eulerAngles = new Vector3(0, transform.rotation.y * 360, 0);

   	if (Input.GetMouseButtonDown(0)) SpawnPortal(blueportal);

	if (Input.GetMouseButtonDown(1)) SpawnPortal(orangeportal);
    }

    void SpawnPortal(GameObject portal){

	    globals.lastPortal = portal;

		int layerMask = 1 << 8;
		layerMask = ~layerMask;
		
		Ray ray = cam.ScreenPointToRay(new Vector3((Screen.width/2)-1, (Screen.height/2)-1, 0));
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)){

			if (portal.activeInHierarchy == false) portal.SetActive(true);
			Debug.Log(hit.point);
			portal.transform.position = hit.point;
			portal.transform.rotation = hit.transform.rotation;
	
			if ((portal.transform.rotation.x <=45 && portal.transform.rotation.x >= -45) || (portal.transform.rotation.z <= 45 && portal.transform.rotation.z >= -45))
			portal.transform.eulerAngles = new Vector3(portal.transform.rotation.x, transform.rotation.y * 360, portal.transform.rotation.z);
		}
		else
		Debug.Log("Failed");
    }
}
