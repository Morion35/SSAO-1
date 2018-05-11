using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class Dash : MonoBehaviour {

	private float cost = 20f;
	private float damage = 25f;
	private float time;
	private float _time;

	private Rigidbody rb;
	private GameObject[] enemies;
	private GameObject[] players;
	private PlayerStatus _status;
	private FirstPersonController Controller;
	
	void Start ()
	{
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		players = GameObject.FindGameObjectsWithTag("Player");
		_status = GetComponentInParent<PlayerStatus>();
		Controller = GetComponentInParent<FirstPersonController>();
		_status.mana -= cost;
		time = Time.time;
		_time = GetComponent<TimeToLive>().TTL - 0.1f;
	}

	private void Update()
	{
		Controller.m_WalkSpeed = 2.5f*(Time.time - time + 1);
		if (Time.time >= time + _time)
		{
			Controller.m_WalkSpeed = 1.1f;
			foreach (GameObject player in players)
			{
				player.GetComponent<PlayerStatus>().armor = player.GetComponent<PlayerStatus>()._basearmor;
			}
			foreach (GameObject enemy in enemies)
			{
				if( enemy != null && GameObject.Find("Spark") == null)
				{
					enemy.GetComponent<NavMeshAgent>().speed = 1;
				}
			}
		}
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") || other.CompareTag("enemy"))
		{
			if (other.CompareTag("Player"))
			{
				other.GetComponent<PlayerStatus>().armor *= 2;
				other.GetComponent<PlayerStatus>().HP -= damage - (damage * other.GetComponent<PlayerStatus>().armor / 100);
			}

			if (other.CompareTag("enemy"))
			{
				other.GetComponent<NavMeshAgent>().speed = 0;
				other.GetComponent<enemyMovement>().HP -= damage;
			}
		}
	}
}
