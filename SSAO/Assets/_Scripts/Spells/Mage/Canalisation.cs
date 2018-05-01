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
	private PlayerStatus status = GameObject.Find("Mage").GetComponent<PlayerStatus>();
	private FirstPersonController FPS = GameObject.Find("Mage").GetComponent<FirstPersonController>();
	
	void Start ()
	{
		status.mana -= cost;
		status.HP -= damage;
		FPS.m_WalkSpeed = 0;
		time = Time.time;
		_time = GetComponent<TimeToLive>().TTL - 0.1f;
	}

	private void Update()
	{
		status.mana -= 5f * Time.deltaTime;
		if (Time.time >= time + _time)
		{
			FPS.m_WalkSpeed = 1;
		}
	}
}
