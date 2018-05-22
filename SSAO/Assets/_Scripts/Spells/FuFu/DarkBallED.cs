using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.AI;

public class DarkBallED : MonoBehaviour {

	private float cost = 100f;
	private float damage = 75f;

	private float mana;

	private GameObject[] enemies = { };
	private GameObject[] players = { };

	void Awake()
	{
		GetComponentInParent<PlayerStatus>().mana -= cost;
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		players = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject enemy in enemies)
		{
			if (enemy != null && (enemy.transform.position - transform.position).magnitude <= 2f)
			{
				if (enemy.GetComponent<enemyMovement>().Player == GameObject.Find("FuFu").transform && enemy.GetComponent<enemyMovement>().isFocused)
				{
					enemy.GetComponent<enemyMovement>().HP -= damage/2;
				}
				else
				{
					enemy.GetComponent<enemyMovement>().HP -= damage;
				}
				
			}
		}

		foreach (GameObject player in players)
		{
			if ((player.transform.position - transform.position).magnitude <= 2f)
			{
				player.GetComponent<PlayerStatus>().HP -= (damage - (damage * player.GetComponent<PlayerStatus>().armor / 100));
			}
		}
	}
}
