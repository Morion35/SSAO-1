using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenuComponent : MonoBehaviour {

	// Use this for initialization
	public GameObject cam;
	void Start ()
	{
		if (transform.parent.gameObject.activeSelf)
		{
			Time.timeScale = 0f;
		}
		
	}
	public void MainMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(0);
	}
	public void Resume()
	{
		cam.GetComponent<FirstPersonController>().paused = false;
	}

	public void Quit()
	{
		Application.Quit();
	}
}
