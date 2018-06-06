using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMover : MonoBehaviour {

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
				if (!other.GetComponent<enemyMovement>().isFocused)
				{
					other.GetComponent<enemyMovement>().hint = true;
					other.GetComponent<enemyMovement>().Player = initial;
				}
			}

			if (other.CompareTag("Player"))
			{
				Destroy(gameObject);
			}
			
			else
			{
				rb.velocity = new Vector3(0,0,0);
				transform.SetPositionAndRotation(transform.position + (transform.forward/10), transform.rotation);
			}
		}
	}
}
