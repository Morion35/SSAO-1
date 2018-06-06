using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;

public class PSNetwork : NetworkBehaviour {

	private Animator anim;

	public Image mana_bar;

	public Image HP_bar;

	public GameObject game_over;

	public const float maxmana = 100f;

	public const float maxHP = 100f;

	[SyncVar]
	public float mana = maxmana;

	[SyncVar]
	public float armor;

	public float _basearmor;

	[SyncVar]
	public float HP = maxHP;

	public bool isdead = false;

	public GameObject deathcam;

	//public GameObject quitbutton;

	//public GameObject MainMenuButton;

	private float timetocam = 5f;

	private float timeofdeath = 0f;
	// Use this for initialization
	void Start ()
	{
		if (!isLocalPlayer)
		{
			anim = GetComponent<Animator>();
		}
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (!isLocalPlayer)
		{
			return;
		}
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
