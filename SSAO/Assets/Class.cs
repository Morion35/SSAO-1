using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class: MonoBehaviour
{


	private GameObject[] Players;
	// Use this for initialization
	void Start ()
	{
		Players = new GameObject[transform.childCount];
		for (int j = 0; j < transform.childCount; j++)
		{
			Players[j] = transform.GetChild(j).gameObject;
		}
		int i = PlayerPrefs.GetInt("Players", 0);
		Players[i].SetActive(true);
	}
}
