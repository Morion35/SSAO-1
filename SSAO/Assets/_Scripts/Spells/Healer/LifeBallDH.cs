﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBallDH : MonoBehaviour {

	private float cost = 5f;
	private float damage = 5f;

	private AudioSource audio;
	void Awake ()
	{
		audio = GetComponent<AudioSource>();
		GetComponentInParent<PlayerStatus>().mana -= cost;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.CompareTag("Spell"))
		{
			if (other.CompareTag("enemy"))
			{
				other.GetComponent<enemyMovement>().HP -= (int)damage;
			}
			if (other.CompareTag("Player"))
			{
				other.GetComponent<PlayerStatus>().HP += (int)damage*2;
			}
			Destroy(gameObject);
		}
		
	}
}
