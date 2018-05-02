using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBallDH : MonoBehaviour {

	private float cost = 5f;
	private float damage = 5f;
	
	void Awake ()
	{
		GetComponentInParent<PlayerStatus>().mana -= cost;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("enemy"))
		{
			other.GetComponent<enemyMovement>().HP -= (int)damage;
		}
		if (other.CompareTag("Player"))
		{
			other.GetComponent<PlayerStatus>().HP += (int)damage/2;
		}
	}
}
