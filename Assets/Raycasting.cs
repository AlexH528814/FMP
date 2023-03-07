using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting : MonoBehaviour
{
	public GameObject blueportal;
	public GameObject orangeportal;
	public int maxPortals = 1;

	Camera cam;

    // Start is called before the first frame update
    void Start()
    {
    	cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

   	if (Input.GetMouseButtonDown(0)) SpawnPortal(blueportal);

	if (Input.GetMouseButtonDown(1)) SpawnPortal(orangeportal);
    }

    void SpawnPortal(GameObject portal){

		int layerMask = 1 << 8;
		layerMask = ~layerMask;
		
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)){

			if (portal.activeInHierarchy == false) portal.SetActive(true);
			Debug.Log(hit.point);
			portal.transform.position = hit.point;
			portal.transform.rotation = hit.transform.rotation;
		}
		else
		Debug.Log("Failed");
    }
}
