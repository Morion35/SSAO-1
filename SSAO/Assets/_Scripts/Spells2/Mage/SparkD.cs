using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class SparkD : MonoBehaviour
{

	private float damage = 2.5f;

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
			if ((enemy.transform.position - transform.position).magnitude <= 0.7f)
			{
				enemy.GetComponent<enemyMovement>().HP -= (int)damage;
				enemy.GetComponent<NavMeshAgent>().speed /= 2;
			}
		}
		foreach (GameObject player in players)
		{
			if ((player.transform.position - transform.position).magnitude <= 0.7f)
			{
				player.GetComponent<PlayerStatus>().HP = (int)(damage)/2;
			}
		}
		Destroy(this);
	}
}
