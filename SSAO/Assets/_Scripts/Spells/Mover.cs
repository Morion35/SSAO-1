using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

	public float speed;
	public GameObject ImpactEffect;
	
	private Rigidbody rb;
	
	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Spell"))
		{
			Destroy(gameObject);
			if (other.CompareTag("enemy"))
			{
				GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0,0.25f,0), other.transform.rotation);
			}
		}
		
	}
}
