using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class Canalisation : MonoBehaviour {

	private float cost = 100f;
	private float damage = 50f;
	private float time;
	private float _time;

	private PlayerStatus _status;

	private FirstPersonController Controller;
	
	void Start ()
	{
		_status = GetComponentInParent<PlayerStatus>();
		_status.mana -= cost;
		_status.HP -= damage;
		Controller = GetComponentInParent<FirstPersonController>();
		Controller.m_WalkSpeed = 0;
		time = Time.time;
		_time = GetComponent<TimeToLive>().TTL - 0.1f;
	}

	private void Update()
	{
		_status.mana -= 5f * Time.deltaTime;
		if (Time.time >= time + _time)
		{
			Controller.m_WalkSpeed = 1;
		}
	}
}
