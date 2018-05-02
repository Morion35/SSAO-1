using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class FireColumnD : MonoBehaviour {

	private float damage = 0.5f;
	
	private GameObject[] enemies;
	private GameObject[] players;
	
	void Start ()
	{
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject enemy in enemies)
		{
			if (enemy != null && (enemy.transform.position - transform.position).magnitude <= 0.5f)
			{
				enemy.GetComponent<enemyMovement>().HP -= damage;
			}
		}
		foreach (GameObject player in players)
		{
			if ((player.transform.position - transform.position).magnitude <= 0.5f)
			{
				player.GetComponent<PlayerStatus>().HP -= damage;
			}
		}
	}
}
