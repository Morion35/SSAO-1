using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	public void LaunchMageZone1()
	{
		SceneManager.LoadScene("plusgrossesave");	// A METTRE ZONE 1 AVEC MAGE
	}
	
	public void LaunchHealerZone1()
	{
		SceneManager.LoadScene("plusgrossesave");	// A METTRE ZONE 1 AVEC HEALER
	}
	
	public void LaunchMulti()
	{
		SceneManager.LoadScene("GameLobby");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
	
}
