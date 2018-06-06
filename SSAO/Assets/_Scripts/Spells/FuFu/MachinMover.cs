using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachinMover : MonoBehaviour
{
	public GameObject Impact;
	private float cost = 20f;

	private float time;
	
	// Use this for initialization
	void Start ()
	{
		time = Time.time;
		GetComponentInParent<PlayerStatus>().mana -= cost;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - time > 0.75f)
		{
			GameObject clone = Instantiate(Impact, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
