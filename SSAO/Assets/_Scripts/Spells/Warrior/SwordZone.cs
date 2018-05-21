using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordZone : MonoBehaviour {

	private float damage = 2.5f;

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("enemy"))
		{
			other.gameObject.GetComponent<enemyMovement>().HP -= damage;
		}
		if (other.gameObject.CompareTag("Player"))
		{
			other.gameObject.GetComponent<PlayerStatus>().HP -= damage - (damage*other.gameObject.GetComponent<PlayerStatus>().armor/100);
		}
	}
	
	
}
