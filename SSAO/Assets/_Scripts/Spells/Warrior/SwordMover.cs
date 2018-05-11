using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMover : MonoBehaviour {

	public GameObject ImpactEffect;
	
	private float cost = 60f;

	private Transform initial;
	
	private Rigidbody rb;
	
	private void Start()
	{
		initial = transform.parent;
		transform.parent = null;
		GameObject.Find("Warrior").GetComponent<PlayerStatus>().mana -= cost;
	}

	private void OnTriggerEnter(Collider other)
	{
    
		if (!other.CompareTag("Spell"))
		{
			
			if (other.CompareTag("enemy"))
			{
				Destroy(gameObject);
				GameObject clone = Instantiate(ImpactEffect, transform.position, ImpactEffect.transform.rotation);
			}
		}
		
	}
}
