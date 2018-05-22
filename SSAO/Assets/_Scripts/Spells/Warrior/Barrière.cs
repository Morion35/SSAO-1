using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class Barrière : MonoBehaviour {

	
	private void OnTriggerEnter(Collider other)
	{
    
		if (!other.CompareTag("Spell"))
		{
			if (other.CompareTag("enemy"))
			{
				other.GetComponent<NavMeshAgent>().speed = 0;
			}
			
			if (other.CompareTag("Player"))
			{
				other.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
			}
		}
	}
}
