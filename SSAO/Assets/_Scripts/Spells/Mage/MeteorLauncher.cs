using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorLauncher : MonoBehaviour {

	
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
			if (other.CompareTag("porte"))
			{
				other.GetComponent<porte>().HP -= 20;
			}
			if (other.CompareTag("enemy"))
			{
            
				GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0,200f,0), other.transform.rotation);
				if (!other.GetComponent<enemyMovement>().isFocused)
				{
					other.GetComponent<enemyMovement>().hint = true;
					other.GetComponent<enemyMovement>().Player = initial;
				}
            
			}

			if (other.CompareTag("Player"))
			{
				GameObject clone = Instantiate(ImpactEffect, other.transform.position + new Vector3(0,200f,0), other.transform.rotation);
			}
		}
	}
}
