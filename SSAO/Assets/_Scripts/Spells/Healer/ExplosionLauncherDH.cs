using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;


public class ExplosionLauncherDH : MonoBehaviour {

	private float cost = 60f;
	private float damage = 50f;
	
	void Start ()
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
