using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flammes : MonoBehaviour
{

	public float damages;

	private GameObject[] players;
	
	void Start ()
	{
		players = GameObject.FindGameObjectsWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject player in players)
		{
			if (GetComponent<Collider>().bounds.Contains(player.transform.position))
			{
				player.GetComponent<PlayerStatus>().HP -= (damages - (damages*player.GetComponent<PlayerStatus>().armor/100));
			}
		}
	}
}
