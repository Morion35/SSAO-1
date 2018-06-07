﻿using System.Collections;
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
			Instantiate(ImpactEffect, other.transform.position + new Vector3(0,200f,0), other.transform.rotation);
		}
			
		if (other.CompareTag("Player"))
		{
			Instantiate(ImpactEffect, other.transform.position + new Vector3(0,200f,0), other.transform.rotation);
		}
	}
}
