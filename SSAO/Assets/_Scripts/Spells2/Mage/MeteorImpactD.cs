using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorImpactD : MonoBehaviour
{

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
			if ((enemy.transform.position - transform.position).magnitude < 3f)
			{
				enemy.GetComponent<enemyMovement>().HP = 1;
			}
		}
		foreach (GameObject player in players)
		{
			if ((player.transform.position - transform.position).magnitude < 3f)
			{
				player.GetComponent<PlayerStatus>().HP = 1;
			}
		}
	}
}
