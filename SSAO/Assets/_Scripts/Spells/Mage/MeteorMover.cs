using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour {

	public GameObject ImpactEffect;
	public GameObject meteorTrigger;
	

	private void FixedUpdate()
	{
		if (transform.position.y < 0)
		{
			Destroy(gameObject);
			GameObject clone = Instantiate(ImpactEffect, new Vector3(transform.position.x, 0, transform.position.z),
				transform.rotation);
			GameObject clone1 = Instantiate(meteorTrigger, new Vector3(transform.position.x, 0.3f, transform.position.z),
				transform.rotation);
		}
	}
}
