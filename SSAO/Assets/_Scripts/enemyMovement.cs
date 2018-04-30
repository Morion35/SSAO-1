using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour {

    Transform Player;

	public int HP = 100;

	private GameObject[] Players;
	
	AudioSource audio;

    UnityEngine.AI.NavMeshAgent nav;

	float _time;

	private float _fov = 60f;

    Animator anim;

    private Vector3 initialPos;

	private Quaternion initialDir;

	// Use this for initialization
	void Awake () {
        initialPos = transform.position;

		initialDir = transform.rotation;

		Players = GameObject.FindGameObjectsWithTag("Player");

		Player = Players[0].transform;

		audio = Players[0].GetComponent<AudioSource>();

        nav = GetComponent<NavMeshAgent>();

        anim = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (HP == 0)
		{
			anim.SetTrigger("dead");
			Destroy(this);
		}
	    NavMeshHit hit;
		Vector3 targetDir = Player.position - transform.position;
		float angle = Vector3.Angle(targetDir, transform.forward);
		if ((targetDir).magnitude < 3f && !nav.Raycast(Player.position, out hit) && angle < _fov || audio.minDistance > targetDir.magnitude)
		{
			_time = 0f;
			nav.isStopped = false;
			anim.SetBool("walking",false);
			anim.SetBool("suspicious", false);
			anim.SetBool("detected", true);
			nav.SetDestination(Player.position);
		}
		else
		{
			if (anim.GetBool("detected") && (Player.position - transform.position).magnitude < 2f)
			{
				_time = 0f;
				nav.isStopped = false;
				anim.SetBool("walking",false);
				anim.SetBool("suspicious", false);
				anim.SetBool("detected", true);
				nav.SetDestination(Player.position);
			}
			
			if (audio.maxDistance > targetDir.magnitude)
			{
				anim.SetBool("suspicious",true);
				_fov = 90f;
			}
			if ((nav.destination - transform.position).magnitude <= 0.2f)
			{
				anim.SetBool("detected", false);
				if (anim.GetBool("walking"))
				{
					if (_time > 3f)
					{
						anim.SetBool("suspicious", false);
						_fov = 60f;
						_time = 0f;
					}
					anim.SetBool("walking",false);
					nav.isStopped = true;
					transform.rotation = initialDir;
				}
				else
				{
					anim.SetBool("suspicious",true);
					if (_time > 3f)
					{
						anim.SetBool("suspicious", false);
						anim.SetBool("walking", true);
						nav.SetDestination(initialPos);
						_time = 0f;
					}
				}
				if (anim.GetBool("suspicious"))
				{
					_time += Time.deltaTime;
				}
			}
		}
		if (!((Player.position - transform.position).magnitude < 3f && !nav.Raycast(Player.position, out hit) && angle < _fov || audio.minDistance > targetDir.magnitude))
		{
			foreach (GameObject player in Players)
			{
				if (player.GetComponent<AudioSource>().minDistance > (player.transform.position - transform.position).magnitude || Vector3.Angle(player.transform.position - transform.position, transform.forward) < _fov && (player.transform.position - transform.position).magnitude < 3f && !nav.Raycast(player.transform.position, out hit))
				{
					Player = player.transform;
					audio = player.GetComponent<AudioSource>();
					break;
				}
				if ((player.transform.position - transform.position).magnitude < (Player.position - transform.position).magnitude)
				{
					Player = player.transform;
					audio = player.GetComponent<AudioSource>();
				}
			}
		}
    }
}
