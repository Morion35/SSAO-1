using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeD : MonoBehaviour {

	private float cost = 5f;
	private float damage = 40f;
	
	void Awake ()
	{
		GetComponentInParent<PlayerStatus>().mana -= cost;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("enemy"))
		{
			if (!(other.GetComponent<enemyMovement>().Player == GameObject.Find("FuFu").transform &&
			      other.GetComponent<enemyMovement>().isFocused))
			{
				other.GetComponent<enemyMovement>().HP -= damage;
			}
			else
			{
				other.GetComponent<enemyMovement>().HP -= damage / 2;
			}
		}
		if (other.CompareTag("Player"))
		{
			other.GetComponent<PlayerStatus>().HP -= (damage - (damage*other.GetComponent<PlayerStatus>().armor/100));
		}
	}
}
