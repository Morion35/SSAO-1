using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShooting : NetworkBehaviour {
	
	public GameObject skillshot;
	public GameObject impulsion;
	public GameObject spell1;
	public GameObject Ulti;
	public GameObject Launcher;
	public Transform shotspawn;
	public float UseRate;
	public float SpellRate;
	public float Ultrate;
	public float DashRate;
	public GameObject Object1;
	public GameObject Object2;
	public GameObject Object3;
	public GameObject Object4;
        
	private float nextDash;
	private float nextUse;
	private float nextSpell;
	private float nextUlt;
	private float Launch;
	private float mana;
	
	bool canShoot;
	
	// Use this for initialization
	void Start ()
	{

		if (isLocalPlayer)
		{
			canShoot = true;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (!canShoot)
		{
			return;
		}
			
		
		
		if (Input.GetButton("Fire1") && Time.time > nextUse && mana >= 5f)
		{
			nextUse = Time.time + UseRate;
			GameObject clone = Instantiate(skillshot, shotspawn.position, shotspawn.rotation, transform);
		}
            
		if (Input.GetButton("Fire2") && Time.time > nextDash && mana >= 20f)
		{
			nextDash = Time.time + DashRate;
			Vector3 dash = transform.forward * 2;
			transform.position += dash;
			GameObject clone1 = Instantiate(impulsion, transform.position, transform.rotation, transform);
		}
            
		if (Input.GetButton("Fire3") && Time.time > nextSpell && mana >= 60f)
		{
			nextSpell = Time.time + SpellRate;
			GameObject clone = Instantiate(spell1, shotspawn.position, shotspawn.rotation, transform);
		}
            
		if (Input.GetButtonDown("Fire4") && Time.time > nextUlt && mana >= 100f)
		{
			nextUlt = Time.time + Ultrate;
			Launch = Time.time + 10f;
			GameObject clone2 = Instantiate(Ulti, transform.position, transform.rotation, transform);
			GameObject clone3 = Instantiate(Launcher, shotspawn.position, shotspawn.rotation, transform);
		}
		
	}
}
