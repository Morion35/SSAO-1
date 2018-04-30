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

	public int maxHP = 100;

	public float mana;

	public int HP;
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
			anim.SetTrigger("dead");
			Destroy(this);
			return;
		}
		if (mana < maxmana)
		{
			mana += 5 * Time.deltaTime;
		}
		HP_bar.fillAmount = (float) HP / maxHP;
		mana_bar.fillAmount = mana / maxmana;
		
	}
}
