using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinMover : MonoBehaviour {

	public GameObject ImpactEffect;

	private float _time;
	private float time = 0.75f;

	private void Start()
	{
		_time = Time.time;
	}

	private void Update()
	{
		if (time <= Time.time - _time)
		{
			Destroy(gameObject);
			GameObject clone = Instantiate(ImpactEffect, transform.position, transform.rotation);
		}
	}
}
