using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
	
	private float damage = 40f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("enemy"))
		{
			if (other.GetComponent<enemyMovement>().Player == GameObject.Find("FuFu").transform &&
			    other.GetComponent<enemyMovement>().isFocused)
			{
				other.GetComponent<enemyMovement>().HP -= damage;
			}
			else
			{
				other.GetComponent<enemyMovement>().HP -= damage / 2;
			}
		}
		if (other.CompareTag("Player") && (other.transform.position - transform.position).magnitude >= 0.05f && !(other.gameObject == GameObject.Find("FuFu")))
		{
			other.GetComponent<PlayerStatus>().HP -= (damage - (damage*other.GetComponent<PlayerStatus>().armor/100));
		}
	}
}
