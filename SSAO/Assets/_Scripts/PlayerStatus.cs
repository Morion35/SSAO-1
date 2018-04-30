using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
	private Animator anim;

	public Image mana_bar;

	public Image HP_bar;

	public float maxmana = 100;

	public float maxHP = 100;

	public float mana;

	public float HP;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		HP = maxHP;
		mana = maxmana;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		if (HP == 0)
		{
			anim.SetBool("death", true);
			Destroy(gameObject, 3);
			return;
		}
		if (mana < maxmana)
		{
			mana += 5 * Time.deltaTime;
		}
		if (HP > 0f)
		{
			HP -= 10 * Time.deltaTime;
		}
		else
		{
			HP = 0f;
		}

		HP_bar.fillAmount = HP / maxHP;
		mana_bar.fillAmount = mana / maxmana;
		
	}
}
