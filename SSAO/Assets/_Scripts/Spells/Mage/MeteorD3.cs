﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorD3 : MonoBehaviour {

	private float damage = 25f;
	
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
