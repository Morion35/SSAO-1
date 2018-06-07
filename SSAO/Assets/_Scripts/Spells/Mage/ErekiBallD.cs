using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ErekiBallD : MonoBehaviour
{
	private float cost = 5f;
	private float damage = 10;
	
	void Awake ()
	{
		GetComponentInParent<PSNetwork>().mana -= cost;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("enemy"))
		{
			other.GetComponent<EMNetwork>().Damage(damage);
		}
		if (other.CompareTag("Player"))
		{
			other.GetComponent<PSNetwork>().Damage(damage);
		}
		Destroy(gameObject);
	}
}
