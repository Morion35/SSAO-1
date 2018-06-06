using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deathmenu : MonoBehaviour {

	
	public void Quit()
	{
		Application.Quit();
	}

	public void MainMenu()
	{
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
		SceneManager.LoadScene(0);
		
	}
}
