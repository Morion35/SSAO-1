using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impulsion1D : MonoBehaviour {

	private float cost = 20f;
	private float damage = 20f;
	
	void Start ()
	{
		GetComponentInParent<PlayerStatus>().mana -= cost;
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("enemy"))
		{
			other.GetComponent<enemyMovement>().HP -= damage;
		}
		if (other.CompareTag("Player") && (other.transform.position - transform.position).magnitude >= 0.05f )
		{
			other.GetComponent<PlayerStatus>().HP -= (damage - (damage*other.GetComponent<PlayerStatus>().armor/100));
		}
	}
}
