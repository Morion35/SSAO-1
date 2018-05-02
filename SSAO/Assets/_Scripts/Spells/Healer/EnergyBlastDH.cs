using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBlastDH : MonoBehaviour {

	private float damage = 0.5f;
	private float cost = 100f;
	private float Selfdamage = 50f;
	private float time;
	private float _time;
	
	private PlayerStatus _status;
	
	private GameObject[] enemies;
	private GameObject[] players;
	
	void Start ()
	{
		enemies = GameObject.FindGameObjectsWithTag("enemy");
		players = GameObject.FindGameObjectsWithTag("Player");
		_status = GetComponentInParent<PlayerStatus>();
		_status.mana -= cost;
		_status.HP -= Selfdamage;
	}
	
	// Update is called once per frame
	void Update () {
		_status.mana -= 5f * Time.deltaTime;
		
		foreach (GameObject enemy in enemies)
		{
			if (enemy != null && (enemy.transform.position - transform.position).magnitude <= 0.5f)
			{
				enemy.GetComponent<enemyMovement>().HP -= damage/2;
			}
		}
		foreach (GameObject player in players)
		{
			if ((player.transform.position - transform.position).magnitude <= 0.5f)
			{
				player.GetComponent<PlayerStatus>().HP += damage;
			}
		}
	}
}
