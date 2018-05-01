using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorD2 : MonoBehaviour {

	private float damage = 50f;
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("enemy"))
		{
			other.GetComponent<enemyMovement>().HP -= (int) damage;
		}

		if (other.CompareTag("Player"))
		{
			other.GetComponent<PlayerStatus>().HP -= (int) damage;
		}
	}
	
}
