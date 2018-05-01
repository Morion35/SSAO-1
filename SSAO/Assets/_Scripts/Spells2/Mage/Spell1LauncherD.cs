using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class Spell1LauncherD : MonoBehaviour {

	private float cost = 60f;
	private float damage = 100;
	
	void Start ()
	{
		GameObject.Find("Mage").GetComponent<PlayerStatus>().mana -= cost;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("enemy"))
		{
			other.GetComponent<NavMeshAgent>().speed = 0;
			other.GetComponent<enemyMovement>().HP -= (int)damage;
		}
		if (other.CompareTag("Player"))
		{
			other.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
			other.GetComponent<PlayerStatus>().HP -= (int)damage/2;
		}
	}
}
