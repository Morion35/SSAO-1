using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonneau : MonoBehaviour
{

	public GameObject Explosion;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Spell"))
		{
			GameObject clone = Instantiate(Explosion, transform.position, transform.rotation);
		}
	}
}
