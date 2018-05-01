using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

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
        
            Destroy(gameObject);
            if (other.CompareTag("enemy"))
            {
            
                GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0,0.25f,0), other.transform.rotation);
                if (!other.GetComponent<enemyMovement>().isFocused)
                {
                   other.GetComponent<enemyMovement>().hint = true;
                   other.GetComponent<enemyMovement>().Player = initial;
                }
            
            } 
        }
    }

}
