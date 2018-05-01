using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErekiBallD : MonoBehaviour
{
	private float cost = 5f;
	private float damage = 10;
	
	void Start ()
	{
		GameObject.Find("Mage").GetComponent<PlayerStatus>().mana -= cost;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("enemy"))
		{
			other.GetComponent<enemyMovement>().HP -= (int)damage;
		}
		if (other.CompareTag("Player"))
		{
			other.GetComponent<PlayerStatus>().HP -= (int)damage/2;
		}
	}
}
