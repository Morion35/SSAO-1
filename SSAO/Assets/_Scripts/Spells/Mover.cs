using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using Component = UnityEngine.Component;

public class Mover : MonoBehaviour
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
		    if (GetComponent<MeshFilter>() == null)
		    {
			    Destroy(gameObject);
		    }

		    if (other.CompareTag("porte"))
			{
				if (GetComponent<MeshFilter>() != null)
				{
					Destroy(gameObject);
				}
				other.GetComponent<porte>().HP -= 20;
			}
		    if (other.CompareTag("enemy"))
		    {
			    if (ImpactEffect != null)
			    {
				    Instantiate(ImpactEffect, other.transform.position + new Vector3(0, 0.25f, 0), other.transform.rotation);
			    }
			    if (GetComponent<MeshFilter>() != null)
			    {
				    Destroy(gameObject);
			    }

			    if (!other.GetComponent<enemyMovement>().isFocused)
			    {
				    other.GetComponent<enemyMovement>().hint = true;
				    other.GetComponent<enemyMovement>().Player = initial;
			    }
		    }
		    if (other.CompareTag("Player"))
		    {
			    if (other.GetComponent<PlayerStatus>()._basearmor != 50)
			    {
				    if (GetComponent<MeshFilter>() != null)
				    {
					    Destroy(gameObject);
				    }
				    GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0, 0.25f, 0),
					    other.transform.rotation);
			    }
		    }
	    }
    }

}
