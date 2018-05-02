using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorLauncher : MonoBehaviour {

	
	public float speed;
	public GameObject ImpactEffect;
	
	private Rigidbody rb;

	private Transform parent;
	
	private void Start()
	{
		parent = transform.parent;
		transform.parent = null;
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
	}

	private void OnTriggerEnter(Collider other)
	{
		Destroy(gameObject);
		if (other.CompareTag("enemy"))
		{
<<<<<<< HEAD
			GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0,30f,0), other.transform.rotation);
=======
			GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0,50f,0), other.transform.rotation);
>>>>>>> bd5a329b3f142ba886560b891ea06ffc6e712a54
		}
	}
}
