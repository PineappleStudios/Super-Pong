using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Remove this script when there are actual things to test
public class SphereController : MonoBehaviour {

	private Rigidbody sphere;

	public Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		sphere = GetComponent<Rigidbody>();
		initialPosition = sphere.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Wall")) 
		{
			sphere.gameObject.transform.position = initialPosition;
			sphere.velocity = new Vector3 (0f, 0f, 0f);
		}
	}

}
