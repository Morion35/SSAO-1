using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PSNetwork : NetworkBehaviour {

	private Animator anim;

	public Image mana_bar;

	public Image HP_bar;

	public GameObject game_over;

	public float maxmana = 100f;

	public float maxHP = 100f;

	[SyncVar(hook = "ChangeMana")]
	public float mana;

	[SyncVar]
	public float armor;

	public float _basearmor;

	[SyncVar(hook = "ChangeHP")]
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
		mana = maxmana;
	}

	public void Damage(float damage)
	{
		if (!isServer)
		{
			return;
		}
		HP -= damage - damage * armor / 100;
		
		if (!isdead && HP <= 0)
		{
			timeofdeath = Time.time + timetocam;
			isdead = true;
			anim.SetBool("death", true);
			game_over.SetActive(true);
			tag = "Untagged";
			GetComponent<FirstPersonController>().enabled = false;
		}
	}

	// Update is called once per frame
	void LateUpdate ()
	{
		if (!isServer)
		{
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
	}

	void ChangeHP(float HP)
	{
		HP_bar.fillAmount = HP / maxHP;
	}

	void ChangeMana(float mana)
	{
		mana_bar.fillAmount = mana / maxmana;
	}
	
}
