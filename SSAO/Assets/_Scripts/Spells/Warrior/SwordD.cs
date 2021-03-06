﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordD : MonoBehaviour {

	private float cost = 5f;
	private float damage = 30f;
	
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
