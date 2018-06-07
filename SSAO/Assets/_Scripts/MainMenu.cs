using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


	public StatsMenu StatsMenu;

	public void LaunchMageZone1()
	{
		if (SceneManager.GetSceneByName("plusgrossesave").isLoaded)
		{
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("plusgrossesave"));
		}
		else
		{
			SceneManager.LoadScene("plusgrossesave");// A METTRE ZONE 1 AVEC MAGE
		}
		
		
	}
	
	public void LaunchLevel1()
	{
		StatsMenu.LoadScene();
	}

	public void QuitGame()
	{
		Application.Quit();
	}
	
}
