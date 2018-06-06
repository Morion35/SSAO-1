using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMover : MonoBehaviour {

	public GameObject ImpactEffect;
	public GameObject meteorTrigger;
	private AudioSource audio;

	private void Awake()
	{
		audio = GetComponent<AudioSource>();
	}

	private void FixedUpdate()
	{
		audio.time = 0.3f + audio.time % 0.35f;
		if (transform.position.y <= 0.6f)
		{
			Destroy(gameObject);
			GameObject clone = Instantiate(ImpactEffect, new Vector3(transform.position.x, 0, transform.position.z),
				transform.rotation);
			GameObject clone1 = Instantiate(meteorTrigger, new Vector3(transform.position.x, 0.3f, transform.position.z),
				transform.rotation);
		}
	}
}
