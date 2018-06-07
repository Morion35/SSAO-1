using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using Component = UnityEngine.Component;
public class Mover : NetworkBehaviour
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
<<<<<<< HEAD
    
        if (!other.CompareTag("Spell"))
        {
	        if (other.CompareTag("porte"))
	        {
		        Destroy(gameObject);
		        other.GetComponent<porte>().HP -= 20;
	        }
	        
            if (other.CompareTag("enemy"))
            {
	            if (!isServer)
	            {
		            return;
	            }
	            Destroy(gameObject);
	            if (ImpactEffect != null)
	            {
		            GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0, 0.25f, 0), other.transform.rotation);
		            NetworkServer.Spawn(clone);
	            }
                if (!other.GetComponent<EMNetwork>().isFocused)
                {
                   other.GetComponent<EMNetwork>().hint = true;
                   other.GetComponent<EMNetwork>().Player = initial;
                }
            }

	        if (other.CompareTag("Player"))
	        {
		        if (GetComponent<MeshFilter>() == null && isServer)
		        {
			        GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0,0.25f,0), other.transform.rotation);
			        NetworkServer.Spawn(clone);
			        Destroy(gameObject);
		        }
	        }
        }
=======

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
>>>>>>> upstream/master
    }

}
