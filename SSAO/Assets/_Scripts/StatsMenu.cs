using System.Collections;
using System.Collections.Generic;
using Prototype.NetworkLobby;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class StatsMenu : MonoBehaviour
{

	public static bool IsMulti;

	public void Multi(bool b)
	{
		IsMulti = b;
	}

	public void Class(string player)
	{
			switch (player)
			{
				case "Mage":
					PlayerPrefs.SetInt("Players", 0);
					break;
				case "Warrior":
					PlayerPrefs.SetInt("Players", 1);
					break;
				case "FuFu":
					PlayerPrefs.SetInt("Players", 2);
					break;
				default:
					PlayerPrefs.SetInt("Players", 3);
					break;
			}
	}

	public void LoadScene()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			if (IsMulti)
			{
				SceneManager.LoadScene(1);
			}
			else
			{
				SceneManager.LoadScene(2);
			}
		}
	}
}
