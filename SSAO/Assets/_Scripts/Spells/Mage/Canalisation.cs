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
	
	void Start ()
	{
		GameObject.Find("Mage").GetComponent<PlayerStatus>().mana -= cost;
		GameObject.Find("Mage").GetComponent<PlayerStatus>().HP -= damage;
		GameObject.Find("Mage").GetComponent<FirstPersonController>().m_WalkSpeed = 0;
		time = Time.time;
		_time = GetComponent<TimeToLive>().TTL - 0.1f;
	}

	private void Update()
	{
		GameObject.Find("Mage").GetComponent<PlayerStatus>().mana -= 5f * Time.deltaTime;
		if (Time.time >= time + _time)
		{
			GameObject.Find("Mage").GetComponent<FirstPersonController>().m_WalkSpeed = 1;
		}
	}
}
