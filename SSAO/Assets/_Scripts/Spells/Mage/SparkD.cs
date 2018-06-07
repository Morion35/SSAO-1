using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class SparkD : MonoBehaviour
{

	private float damage = 2.5f;
	private float time;
	private float _time;
	private AudioSource audio;
	private GameObject[] enemies;
	private GameObject[] players;
	
	void Start ()
	{
		audio = GetComponent<AudioSource>();
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		players = GameObject.FindGameObjectsWithTag("Player");
		audio.Play();
		foreach (GameObject enemy in enemies)
		{
			if (enemy != null && (enemy.transform.position - transform.position).magnitude <= 0.7f)
			{
				enemy.GetComponent<enemyMovement>().HP -= (damage);
				enemy.GetComponent<NavMeshAgent>().speed /= 2;
			}
		}
		foreach (GameObject player in players)
		{
			if ((player.transform.position - transform.position).magnitude <= 0.7f)
			{
				player.GetComponent<PlayerStatus>().HP -= (damage - (damage*player.GetComponent<PlayerStatus>().armor/100));
			}
		}
		time = Time.time;
		_time = GetComponent<TimeToLive>().TTL - 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= time + _time)
		{
			foreach (GameObject enemy in enemies)
			{
				if( enemy != null && GameObject.Find("Shield") == null)
				{
					enemy.GetComponent<NavMeshAgent>().speed = 1;
				}
			}
		}
	}
}
