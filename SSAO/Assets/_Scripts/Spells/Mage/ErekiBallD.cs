using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErekiBallD : MonoBehaviour
{
	private float cost = 5f;
	private float damage = 10;
	
	void Awake ()
	{
		GetComponentInParent<PlayerStatus>().mana -= cost;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("enemy"))
		{
			other.GetComponent<enemyMovement>().HP -= damage;
		}
		if (other.CompareTag("Player"))
		{
			other.GetComponent<PlayerStatus>().HP -= (damage - (damage*other.GetComponent<PlayerStatus>().armor/100));
		}
	}
}
