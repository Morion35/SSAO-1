using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moverbis : MonoBehaviour {

	
	
	public float speed;
	public GameObject ImpactEffect;

	private Transform initial;
	
	private Rigidbody rb;
	
	private void Start()
	{
		initial = transform.parent;
		transform.parent = null;
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
	}

	private void OnTriggerEnter(Collider other)
	{
    
		if (!other.CompareTag("Spell"))
		{
	        
			if (other.CompareTag("porte"))
			{
				Destroy(gameObject);
				other.GetComponent<porte>().HP -= 20;
			}
	        
			else if (other.CompareTag("enemy"))
			{
				Destroy(gameObject);
				GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0,0.25f,0), other.transform.rotation, other.transform);
				if (!other.GetComponent<enemyMovement>().isFocused)
				{
					other.GetComponent<enemyMovement>().hint = true;
					other.GetComponent<enemyMovement>().Player = initial;
				}
			}

			else if (other.CompareTag("Player"))
			{
				if (GetComponent<MeshFilter>() == null)
				{
					GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0,0.25f,0), other.transform.rotation, other.transform);
					Destroy(gameObject);
				}
			}
			else
			{
				Destroy(gameObject);
			}
	        
		}
	}
}
