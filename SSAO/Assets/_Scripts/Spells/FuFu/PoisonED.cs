using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PoisonED : MonoBehaviour
{

	public float damage = 5f;

	public GameObject Curse;
	private enemyMovement enemy;

	private void Start()
	{
		enemy = GetComponentInParent<enemyMovement>();
	}

	private void Update()
	{
		if (enemy != null)
		{
			enemy.HP -= damage*Time.deltaTime;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("enemy"))
		{
			if (other.GetComponentInChildren<PoisonED>() == null)
			{
				GameObject clone = Instantiate(Curse, other.transform.position + new Vector3(0, 0.25f, 0), other.transform.rotation, other.transform);
			}
		}
	}
}
