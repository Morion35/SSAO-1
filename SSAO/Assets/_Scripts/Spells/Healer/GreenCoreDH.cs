using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCoreDH : MonoBehaviour {

	private float damage = 0.3f;
	
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
			if (enemy != null && (enemy.transform.position - transform.position).magnitude <= 1f)
			{
				enemy.GetComponent<enemyMovement>().HP -= damage/2;
			}
		}
		foreach (GameObject player in players)
		{
			if ((player.transform.position - transform.position).magnitude <= 1f)
			{
				player.GetComponent<PlayerStatus>().HP += damage;
			}
		}
	}
}
