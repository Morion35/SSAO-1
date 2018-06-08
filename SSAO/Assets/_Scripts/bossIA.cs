using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bossIA : MonoBehaviour {

	public bool isFocused;

	public bool hint;

	public Transform Player;

	public float HP = 100;
	
	private GameObject[] Players;
	
	AudioSource audio;

    UnityEngine.AI.NavMeshAgent nav;

	float _time;

	private float _fov = 60f;

    Animator anim;

    private Vector3 initialPos;

	private Quaternion initialDir;

	public float firetime = 5f;

	public float damage = 10f;

	private float fireuse;

	// Use this for initialization
	void Start () {
        initialPos = transform.position;
		
		initialDir = transform.rotation;

		Players = GameObject.FindGameObjectsWithTag("Player");

		int i = 0;
		while (i < Players.Length && !Players[i].activeSelf)
		{
			i++;
		}
		Player = Players[i].transform;

		isFocused = false;

		audio = Players[0].GetComponent<AudioSource>();

        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
		fireuse = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (HP <= 0)
		{
			nav.isStopped = true;
			Destroy(gameObject, 3f);
			return;
		}
	    NavMeshHit hit;
		Vector3 targetDir = Player.position - transform.position;
		if (Vector3.Angle((Player.position - transform.position), Vector3.forward) < 10f && Time.time > fireuse)
		{
			fireuse = Time.time + firetime;
			Player.GetComponent<PlayerStatus>().HP -=
				damage - (damage * Player.GetComponent<PlayerStatus>().armor / 100);
		}
		if (Player.GetComponent<PlayerStatus>().isdead)
		{
			Players = GameObject.FindGameObjectsWithTag("Player");
			isFocused = false;
			Player = Players[0].transform;
		}
    }

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("porte"))
		{
			other.gameObject.GetComponent<porte>().HP = 0;
		}
	}
}
