using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour {

	public GameObject ImpactEffect;
	private Rigidbody rb;
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (transform.position.y <= 0)
		{
			Destroy(gameObject);
			GameObject clone = Instantiate(ImpactEffect, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
			
		}
	}
}
