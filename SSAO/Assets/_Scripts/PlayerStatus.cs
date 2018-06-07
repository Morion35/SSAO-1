using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Networking;

public class PlayerStatus : MonoBehaviour
{
	private Animator anim;

	public Image mana_bar;

	public Image HP_bar;

	public GameObject game_over;

	public float maxmana = 100;

	public float maxHP = 100;

	public float mana;

	public float armor;

	public float _basearmor;

	public float HP;

	public bool isdead = false;

	public GameObject deathcam;

	//public GameObject quitbutton;

	//public GameObject MainMenuButton;

	private float timetocam = 5f;

	private float timeofdeath = 0f;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		HP = maxHP;
		_basearmor = armor;
		mana = maxmana;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (!isdead && HP <= 0)
		{
			timeofdeath = Time.time + timetocam;
			isdead = true;
			anim.SetBool("death", true);
			game_over.SetActive(true);
			tag = "Untagged";
			GetComponent<FirstPersonController>().enabled = false;
			return;
		}
		if (isdead && Time.time >= timeofdeath)
		{
			game_over.SetActive(false);
			deathcam.SetActive(true);
			gameObject.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
			gameObject.SetActive(false);
			return;
		}
		if (mana < maxmana)
		{
			mana += 5 * Time.deltaTime;
		}

		if (HP >= 100f)
		{
			HP = 100f;
		}
		
		HP_bar.fillAmount = HP / maxHP;
		mana_bar.fillAmount = mana / maxmana;
	}

	
}
