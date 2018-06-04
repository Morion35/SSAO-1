using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

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
	        
			if (other.CompareTag("enemy"))
			{
				Destroy(gameObject);
				GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0,0.25f,0), other.transform.rotation);
			}

			if (other.CompareTag("Player"))
			{
				if (GetComponent<MeshFilter>() == null)
				{
					GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0,0.25f,0), other.transform.rotation);
					Destroy(gameObject);
				}
			}
			else
			{
				rb.velocity = new Vector3(0,0,0);
				transform.SetPositionAndRotation(transform.position + (transform.forward/10), transform.rotation);
			}
		}
	}
}
